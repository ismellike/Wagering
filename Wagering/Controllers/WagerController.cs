using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private const int ResultSize = 15;
        public struct Query
        {
            public string game;
            public int page;
            public string username;
            public int? minimumWager;
            public int? maximumWager;
            public int? playerCount;
        }
        public struct WagerResult
        {
            public int Id { get; set; }
            public string Group { get; set; }
            public IEnumerable<string> Users { get; set; }
        }

        public WagerController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMemoryCache cache)
        {
            _userManager = userManager;
            _context = context;
            _cache = cache;
        }

        //POST: api/wagers/search
        [HttpPost("search")]
        public async Task<IActionResult> GetWagers([FromBody]Query query)
        {
            if (query.page < 1)
                ModelState.AddModelError("Page", $"{query.page} is not a valid page.");
            if (query.minimumWager.HasValue && query.maximumWager.HasValue && query.minimumWager.Value > query.maximumWager.Value)
                ModelState.AddModelError("Greater than", "Minimum wager cannot be larger than the maximum wager.");
            if (query.maximumWager.HasValue && query.maximumWager.Value < 0)
                ModelState.AddModelError("Max Negative", "Maximum wager cannot be negative.");
            if (query.minimumWager.HasValue && query.minimumWager.Value < 0)
                ModelState.AddModelError("Min Negative", "Minimum wager cannot be negative.");
            if (query.playerCount.HasValue && query.playerCount.Value < 0)
                ModelState.AddModelError("Player Negative", "Player count cannot be negative.");

            Game Game = await _context.Games.FirstOrDefaultAsync(x => x.Url == query.game);
            if (Game == null)
                ModelState.AddModelError("Game", $"{query.game} is not a valid game.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IQueryable<Wager> wagerQuery = _context.Wagers.AsNoTracking().Include(x => x.Hosts).ThenInclude(x => x.User).Where(x => !x.IsPrivate).Where(x => x.Status == 1).Where(x => x.GameName == Game.Name);

            if (query.playerCount.HasValue)
                wagerQuery = wagerQuery.Where(x => x.Hosts.Count == query.playerCount);
            if (query.minimumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MinimumWager == null || (x.MinimumWager.HasValue && x.MinimumWager > query.minimumWager) || (x.MaximumWager.HasValue && x.MaximumWager > query.minimumWager));
            if (query.maximumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MaximumWager == null || (x.MinimumWager.HasValue && x.MinimumWager < query.maximumWager) || (x.MaximumWager.HasValue && x.MaximumWager < query.maximumWager));

            PaginatedList<Wager> wagers = await PaginatedList<Wager>.CreateAsync(wagerQuery.OrderByDescending(x => x.Date).Select(x => new Wager(x) { ChallengeCount = x.Challenges.Count }), query.page, ResultSize);

            return Ok(wagers);
        }

        // GET: api/wagers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWager(int id)
        {
            var wager = await _context.Wagers.AsNoTracking().Include(x => x.Hosts).ThenInclude(x => x.User).Include(x => x.Challenges).FirstOrDefaultAsync(x => x.Id == id);
            wager.ChallengeCount = wager.Challenges.Count;
            if (wager == null)
            {
                ModelState.AddModelError("Not Found", "Wager was not found");
                return BadRequest(ModelState);
            }
            return Ok(wager);
        }

        [HttpGet("host")]
        public async Task<IActionResult> HostWagers()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();
            List<Wager> wagers = await _context.Wagers.AsNoTracking().Where(x => x.Hosts.Any(y => y.UserId == user.Id)).Include(x => x.Hosts).ThenInclude(x => x.User).Select(x => new Wager(x)
            {
                ChallengeCount = x.Challenges.Count
            }).ToListAsync();
            return Ok(wagers);
        }

        [HttpGet("host/{id}")]
        public async Task<IActionResult> GetHostWager(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();

            if (!_cache.TryGetValue(id, out Wager wager))
            {
                wager = await _context.Wagers.AsNoTracking().Include(x => x.Hosts).ThenInclude(x => x.User).Include(x => x.Challenges).ThenInclude(x => x.Challengers).ThenInclude(x => x.User).Include(x => x.Notifications).FirstOrDefaultAsync(x => x.Id == id);
                wager.ChallengeCount = wager.Challenges.Count;

                _cache.Set(id, wager, TimeSpan.FromSeconds(20));
            }

            if (wager == null)
            {
                ModelState.AddModelError("Not Found", "The wager was not found.");
                return BadRequest(ModelState);
            }
            if (!wager.Hosts.Any(x => x.UserId == user.Id))
            {
                ModelState.AddModelError("Not Host", "You are not a host of this wager.");
                return BadRequest(ModelState);
            }
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();

            if (wager.Hosts.Sum(x => x.Percentage) != 100)
            {
                ModelState.AddModelError("Percentage", "The hosts percentages do not add up to 100.");
                return BadRequest(ModelState);
            }

            try
            {
                wager.Hosts.Single(x => x.IsOwner && x.UserId == null).UserId = user.Id;
            }
            catch
            {
                ModelState.AddModelError("Wrong Owner", "Cannot request for someone else to be the owner.");
                return BadRequest(ModelState);
            }

            DateTime date = DateTime.Now;
            Wager newWager = new Wager //prevents overposting
            {
                GameName = wager.GameName,
                Date = date,
                Description = wager.Description,
                MinimumWager = wager.MinimumWager,
                MaximumWager = wager.MaximumWager,
                IsPrivate = wager.IsPrivate,
                Status = 0,
                Hosts = new List<WagerHostBid>(),
                Notifications = new List<EventNotification>()
                {
                    new EventNotification
                    {
                        Message = $"{user.UserName} created the wager.",
                        Date = date
                    }
                }
            };

            foreach (WagerHostBid host in wager.Hosts)
            {
                WagerHostBid bid = new WagerHostBid
                {
                    Approved = null,
                    IsOwner = false,
                    Percentage = host.Percentage,
                    UserId = host.UserId,
                };
                if (host.UserId == user.Id)
                {
                    bid.Approved = true;
                    bid.IsOwner = true;
                }
                newWager.Hosts.Add(bid);
            }

            if (newWager.IsApproved())
                newWager.Status = 1;

            await _context.Wagers.AddAsync(newWager);
            await _context.SaveChangesAsync();

            _cache.Set(newWager.Id, newWager, TimeSpan.FromSeconds(20));
            return Ok(new WagerResult
            {
                Id = newWager.Id,
                Group = newWager.GroupName,
                Users = newWager.Hosts.Select(x => x.UserId).Where(x => x != user.Id)
            });
        }
    }
}
