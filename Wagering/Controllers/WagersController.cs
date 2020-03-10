using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private const int ResultSize = 15;

        public WagersController(ApplicationDbContext context)
        {
            _context = context;
        }
        //POST: api/wagers/search
        [HttpPost("search")]
        public async Task<IActionResult> SearchWagers([FromBody]SearchQuery query)
        {
            if (query.Page < 1)
                return BadRequest($"{query.Page} is not a valid page.");
            if (query.MinimumWager.HasValue && query.MaximumWager.HasValue && query.MinimumWager.Value > query.MaximumWager.Value)
                return BadRequest("Minimum wager cannot be larger than the maximum wager.");
            if (query.MaximumWager.HasValue && query.MaximumWager.Value < 0)
                return BadRequest("Maximum wager cannot be negative.");
            if (query.MinimumWager.HasValue && query.MinimumWager.Value < 0)
                return BadRequest("Minimum wager cannot be negative.");
            if (query.PlayerCount.HasValue && query.PlayerCount.Value < 0)
                return BadRequest("Player count cannot be negative.");

            Game game = await _context.Games.FirstOrDefaultAsync(x => x.Url == query.Game);
            if (game == null)
                return BadRequest($"{query.Game} is not a valid game.");

            IQueryable<Wager> wagerQuery = _context.Wagers.Include(x => x.Game).Include(x => x.Hosts).ThenInclude(x => x.User).Where(x => x.GameName == game.Name);
            if (!query.ShowClosed)
                wagerQuery = wagerQuery.Where(x => x.IsClosed == query.ShowClosed);

            if (!string.IsNullOrWhiteSpace(query.Username))
                wagerQuery = wagerQuery.Where(x => x.Hosts.Any(y => y.User.DisplayName.Contains(query.Username)));
            if (query.PlayerCount.HasValue)
                wagerQuery = wagerQuery.Where(x => x.Hosts.Count == query.PlayerCount);
            if (query.MinimumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MinimumWager == null || (x.MinimumWager.HasValue && x.MinimumWager > query.MinimumWager) || (x.MaximumWager.HasValue && x.MaximumWager > query.MinimumWager));
            if (query.MaximumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MaximumWager == null || (x.MinimumWager.HasValue && x.MinimumWager < query.MaximumWager) || (x.MaximumWager.HasValue && x.MaximumWager < query.MaximumWager));

            PaginatedList<Wager> wagers = await PaginatedList<Wager>.CreateAsync(wagerQuery.OrderByDescending(x => x.Date), query.Page, ResultSize);

            foreach (Wager wager in wagers.List)
                wager.ChallengeCount = await _context.Challenges.Where(x => x.WagerId == wager.Id).CountAsync();

            return Ok(wagers);
        }

        // GET: api/wagers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWager(int id)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).ThenInclude(x => x.User).Include(x => x.Challenges).ThenInclude(x => x.Challengers).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (wager == null)
                return NotFound();
            wager.ChallengeCount = wager.Challenges.Count();
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
        [Authorize]
        public async Task<IActionResult> PostWager(Wager wager)
        {
            //validate wager
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //save wager
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (profile == null)
                return Unauthorized();

            Wager newWager = new Wager //prevents overposting
            {
                GameName = wager.GameName,
                Date = DateTime.Now,
                Description = wager.Description,
                MinimumWager = wager.MinimumWager,
                MaximumWager = wager.MaximumWager,
                IsClosed = true,
                Hosts = new WagerHostBid[]
                {
                    new WagerHostBid
                    {
                        UserDisplayName = profile.DisplayName,
                        Approved = true,
                        Percentage = 100
                    }
                }
            };
            await _context.Wagers.AddAsync(newWager);
            await _context.SaveChangesAsync();
            return Ok(newWager.Id);
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
