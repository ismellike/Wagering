using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Data;
using Wagering.Models;

namespace Wagering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WagersController(ApplicationDbContext context)
        {
            _context = context;
        }
        //POST: api/wagers/search
        [HttpPost("search")]
        public async Task<ActionResult<PaginatedList<Wager>>> GetWagers([FromBody]SearchQuery query)
        {
            if (query.Page < 1 || query.Size < 1)
                return BadRequest();
            List<Game> games = await _context.Games.ToListAsync();
            Game game = games.Find(x => x.Name.ToURL() == query.Game);
            if (game == null)
                return BadRequest();

            IQueryable<Wager> wagerQuery = _context.Wagers.Include(x => x.Game).Include(x => x.Hosts).ThenInclude(x => x.User).Where(x => x.GameId == game.Id).Where(x => x.IsClosed == query.ShowClosed);

            if (!string.IsNullOrWhiteSpace(query.Username))
                wagerQuery = wagerQuery.Where(x => x.Hosts.Any(y => y.User.DisplayName.Contains(query.Username)));
            if (query.PlayerCount.HasValue)
                wagerQuery = wagerQuery.Where(x => x.Hosts.Count == query.PlayerCount);
            if (query.MinimumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MinimumWager == null || (x.MinimumWager.HasValue && x.MinimumWager > query.MinimumWager) || (x.MaximumWager.HasValue && x.MaximumWager > query.MinimumWager));
            if (query.MaximumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MaximumWager == null || (x.MinimumWager.HasValue && x.MinimumWager < query.MaximumWager) || (x.MaximumWager.HasValue && x.MaximumWager < query.MaximumWager));

            PaginatedList<Wager> wagers = await PaginatedList<Wager>.CreateAsync(wagerQuery, query.Page, query.Size);

            foreach (Wager wager in wagers.List)
                wager.ChallengeCount = await _context.Challenges.Where(x => x.WagerId == wager.Id).CountAsync();

            if (wagers == null)
                return NotFound();

            return Ok(wagers);
        }

        // GET: api/Wagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wager>> GetWager(int id)
        {
            var wager = await _context.Wagers.Include(x => x.Game).Include(x => x.Hosts).ThenInclude(x => x.User).Include(x => x.Challenges).ThenInclude(x => x.Challengers).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            wager.ChallengeCount = wager.Challenges.Count();
            if (wager == null)
                return NotFound();
            return Ok(wager);
        }

        // PUT: api/Wagers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWager(int id, Wager wager)
        {
            if (id != wager.Id)
            {
                return BadRequest();
            }

            _context.Entry(wager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WagerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Wagers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Wager>> PostWager(Wager wager)
        {
            _context.Wagers.Add(wager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWager", new { id = wager.Id }, wager);
        }

        // DELETE: api/Wagers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wager>> DeleteWager(int id)
        {
            var wager = await _context.Wagers.FindAsync(id);
            if (wager == null)
            {
                return NotFound();
            }

            _context.Wagers.Remove(wager);
            await _context.SaveChangesAsync();

            return wager;
        }

        private bool WagerExists(int id)
        {
            return _context.Wagers.Any(e => e.Id == id);
        }
    }
}
