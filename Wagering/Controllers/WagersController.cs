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

        public struct Query
        {
            public string game;
            public int page;
            public string username;
            public int? minimumWager;
            public int? maximumWager;
            public int? playerCount;
        }

        //POST: api/wagers/search
        [HttpPost("search")]
        public async Task<IActionResult> GetWagers([FromBody]Query query)
        {
            if (query.page < 1)
                return BadRequest($"{query.page} is not a valid page.");
            if (query.minimumWager.HasValue && query.maximumWager.HasValue && query.minimumWager.Value > query.maximumWager.Value)
                return BadRequest("Minimum wager cannot be larger than the maximum wager.");
            if (query.maximumWager.HasValue && query.maximumWager.Value < 0)
                return BadRequest("Maximum wager cannot be negative.");
            if (query.minimumWager.HasValue && query.minimumWager.Value < 0)
                return BadRequest("Minimum wager cannot be negative.");
            if (query.playerCount.HasValue && query.playerCount.Value < 0)
                return BadRequest("Player count cannot be negative.");

            Game Game = await _context.Games.FirstOrDefaultAsync(x => x.Url == query.game);
            if (Game == null)
                return BadRequest($"{query.game} is not a valid game.");

            IQueryable<Wager> wagerQuery = _context.Wagers.Include(x => x.Game).Include(x => x.Hosts).ThenInclude(x => x.User).Where(x => !x.IsPrivate).Where(x => x.GameName == Game.Name);

            if (!string.IsNullOrWhiteSpace(query.username))
                wagerQuery = wagerQuery.Where(x => x.Hosts.Any(y => y.UserDisplayName.Contains(query.username)));
            if (query.playerCount.HasValue)
                wagerQuery = wagerQuery.Where(x => x.Hosts.Count == query.playerCount);
            if (query.minimumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MinimumWager == null || (x.MinimumWager.HasValue && x.MinimumWager > query.minimumWager) || (x.MaximumWager.HasValue && x.MaximumWager > query.minimumWager));
            if (query.maximumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MaximumWager == null || (x.MinimumWager.HasValue && x.MinimumWager < query.maximumWager) || (x.MaximumWager.HasValue && x.MaximumWager < query.maximumWager));

            PaginatedList<Wager> wagers = await PaginatedList<Wager>.CreateAsync(wagerQuery.OrderByDescending(x => x.Date), query.page, ResultSize);

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

        // POST: api/Wagers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostWager(Wager wager)
        {
            //validate wager
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            Wager newWager = new Wager //prevents overposting
            {
                GameName = wager.GameName,
                Date = DateTime.Now,
                Description = wager.Description,
                MinimumWager = wager.MinimumWager,
                MaximumWager = wager.MaximumWager,
                IsPrivate = true,
                Status = 0,
                Hosts = new WagerHostBid[]
                {
                    new WagerHostBid
                    {
                        UserDisplayName = profile.DisplayName,
                        Approved = false,
                        Percentage = 100
                    }
                }
            };
            await _context.Wagers.AddAsync(newWager);
            await _context.SaveChangesAsync();
            return Ok(newWager.Id);
        }

        [HttpGet("client")]
        [Authorize]
        public async Task<IActionResult> ClientChallenges()
        {
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            var requests = await _context.Challenges.Include(x => x.Challengers).Include(x => x.Wager).Where(x => x.Challengers.Any(x => x.UserDisplayName == profile.DisplayName)).ToListAsync();
            return Ok(requests);
        }

        [HttpGet("host")]
        [Authorize]
        public async Task<IActionResult> HostWagers()
        {
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            var requests = await _context.Wagers.Include(x => x.Challenges).ThenInclude(x => x.Challengers).Where(x => x.Hosts.Any(x => x.UserDisplayName == profile.DisplayName)).ToListAsync();
            return Ok(requests);
        }

        [HttpPost("host/edit")]
        [Authorize]
        public async Task<IActionResult> EditWager(Wager newWager)
        {
            //authorization
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == newWager.Id);
            if (wager == null)
                return BadRequest("Wager was not found.");
            if (!wager.Hosts.Any(x => x.UserDisplayName == profile.DisplayName))
                return Unauthorized();

            //reset all host and client approved to false
            foreach (var host in wager.Hosts)
                host.Approved = false;
            foreach (var challenge in wager.Challenges)
                foreach (var client in challenge.Challengers)
                    client.Approved = false;
            //set new wager
            //need to set percentage ratings & other users
            wager.Description = newWager.Description;
            wager.MinimumWager = newWager.MinimumWager;
            wager.MaximumWager = newWager.MaximumWager;
            wager.IsPrivate = newWager.IsPrivate;

            //save wager
            _context.Wagers.Update(wager);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("host/request")]
        [Authorize]
        public async Task<IActionResult> SendRequest(int wagerId, decimal amount)
        {
            var profile = await GetProfileAsync();
            if (profile == null)
                return Unauthorized();

            //check if wager belongs to user
            var wager = await _context.Wagers.FindAsync(wagerId);
            if (wager == null)
                return BadRequest("Wager was not found.");
            if (!wager.Hosts.Any(x => x.UserDisplayName == profile.DisplayName))
                return Unauthorized($"{profile.DisplayName} cannot request, because they are a host.");
            //send request to user
            //check for balance and hold
            wager.Challenges.Add(new WagerChallenge
            {
                Challengers = new WagerChallengeBid[]
                {
                    new WagerChallengeBid{
                    UserDisplayName = profile.DisplayName,
                    Approved = false,
                    Percentage = 100
                    }
                },
                Date = DateTime.Now,
                Amount = amount,
            });
            return Ok();
        }

        private async Task<Profile> GetProfileAsync()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _context.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
