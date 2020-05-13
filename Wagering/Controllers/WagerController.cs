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
        private readonly ErrorMessages _errorMessages = new ErrorMessages { Name = "wager" };
        public struct Query
        {
            public int gameId;
            public int page;
            public string username;
            public int? minimumWager;
            public int? maximumWager;
            public int? playerCount;
        }

        public WagerController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMemoryCache cache)
        {
            _userManager = userManager;
            _context = context;
            _cache = cache;
        }

        //POST: api/wagers/search
        [HttpPost("search")]
        public async Task<IActionResult> GetWagers([FromBody] Query query)
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

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            byte confirmed = (byte)Status.Confirmed;
            IQueryable<Wager> wagerQuery = _context.Wagers.AsNoTracking().Where(x => x.GameId == query.gameId).Where(x => !x.IsPrivate).Where(x => x.Status == confirmed);

            if (query.playerCount.HasValue)
                wagerQuery = wagerQuery.Where(x => x.Hosts.Count == query.playerCount);
            if (query.minimumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MinimumWager == null || (x.MinimumWager.HasValue && x.MinimumWager > query.minimumWager) || (x.MaximumWager.HasValue && x.MaximumWager > query.minimumWager));
            if (query.maximumWager.HasValue)
                wagerQuery = wagerQuery.Where(x => x.MaximumWager == null || (x.MinimumWager.HasValue && x.MinimumWager < query.maximumWager) || (x.MaximumWager.HasValue && x.MaximumWager < query.maximumWager));

            wagerQuery = wagerQuery.Include(x => x.Hosts).ThenInclude(x => x.Profile);
            PaginatedList<Wager> results = await PaginatedList<Wager>.CreateAsync(wagerQuery.OrderByDescending(x => x.Date), query.page, ResultSize);
            return Ok(results);
        }

        // GET: api/wagers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWager(int id)
        {
            var wager = await _context.Wagers.AsNoTracking().Include(x => x.Hosts).ThenInclude(x => x.Profile).Include(x => x.Challenges).FirstOrDefaultAsync(x => x.Id == id);
            if (wager == null)
            {
                ModelState.AddModelError("Not Found", _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            return Ok(wager);
        }

        [HttpGet("control")]
        [Authorize]
        public async Task<IActionResult> ControlWagers()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }
            List<Wager?> results = await _context.UserGroups.AsNoTracking().Where(x => x.ProfileId == user.Id).Include(x => x.Wager).Select(x => x.Wager).ToListAsync();
            return Ok(results);
        }

        [HttpGet("control/{id}")]
        [Authorize]
        public async Task<IActionResult> GetControlWager(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }

            if (!_cache.TryGetValue(id, out Wager wager))
            {
                wager = await _context.Wagers.AsNoTracking().Include(x => x.Hosts).ThenInclude(x => x.Profile).Include(x => x.Challenges).ThenInclude(x => x.Challengers).ThenInclude(x => x.Profile).FirstOrDefaultAsync(x => x.Id == id);
                _cache.Set(id, wager, TimeSpan.FromSeconds(20));
            }

            if (wager == null)
            {
                ModelState.AddModelError("Not Found", _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (!wager.Hosts.Any(x => x.ProfileId == user.Id))
            {
                ModelState.AddModelError("Not Host", "You are not a host of this wager.");
                return BadRequest(ModelState);
            }
            return Ok(wager);
        }

        [HttpPost("cancel/{id}")]
        [Authorize]
        public async Task<IActionResult> CancelWager(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }
            Wager wager = await _context.Wagers.Include(x => x.Hosts).FirstOrDefaultAsync(x => x.Id == id);

            if (wager == null)
            {
                ModelState.AddModelError("Not Found", _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (!wager.Hosts.Any(x => x.ProfileId == user.Id))
            {
                ModelState.AddModelError("Not Host", "You are not a host of this wager.");
                return BadRequest(ModelState);
            }
            await WagerHandler.Decline(_context, id, user.UserName);
            return Ok();
        }

        // POST: api/Wagers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public IActionResult PostWager(Wager wagerData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? id = User.GetId();
            string? name = User.GetName();
            WagerHostBid caller = wagerData.Hosts.FirstOrDefault(x => x.ProfileId == id);

            if (wagerData.Hosts.Sum(x => x.ReceivablePt) != 100)
                ModelState.AddModelError(string.Empty, "The hosts receivable percentages do not add up to 100.");
            if (wagerData.Hosts.Sum(x => x.PayablePt) != 100)
                ModelState.AddModelError(string.Empty, "The hosts payable percentages do not add up to 100.");
            if (caller == null)
                ModelState.AddModelError(string.Empty, "Caller must be a host.");
            else if (!caller.IsOwner)
                ModelState.AddModelError(string.Empty, "Caller must be the owner.");
            if (!wagerData.HostIds().IsUnique())
                ModelState.AddModelError(string.Empty, "The hosts are not unique.");
            try
            {
                if (wagerData.Hosts.Single(x => x.IsOwner) == null)
                    throw new Exception("Only 1 owner should be specified.");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DateTime date = DateTime.Now;
            Wager wager = new Wager //prevents overposting
            {
                GameId = wagerData.GameId,
                Date = date,
                Description = wagerData.Description,
                MinimumWager = wagerData.MinimumWager,
                MaximumWager = wagerData.MaximumWager,
                IsPrivate = wagerData.IsPrivate,
                Status = 0,
                Hosts = new List<WagerHostBid>(),
                ChallengeCount = 0
            };

            foreach (WagerHostBid host in wagerData.Hosts)
            {
                WagerHostBid bid = new WagerHostBid
                {
                    Approved = null,
                    IsOwner = false,
                    ReceivablePt = host.ReceivablePt,
                    PayablePt = host.PayablePt,
                    ProfileId = host.ProfileId
                };
                if (host.IsOwner)
                {
                    bid.Approved = true;
                    bid.IsOwner = true;
                }
                wager.Hosts.Add(bid);
            }

            if (wager.IsApproved())
                wager.Status = 1;

            _context.Wagers.Add(wager);
            _context.SaveChanges();
            PersonalNotification notification = new PersonalNotification
            {
                Date = date,
                Message = $"{name} created a wager with you.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            IEnumerable<string> users = wager.HostIds();
            IEnumerable<string> others = users.Where(x => x != id);
            NotificationHandler.AddNotificationToUsers(_context, others, notification);
            WagerHandler.AddUserGroups(_context, wager.Id, users);
            _context.SaveChanges();
            _cache.Set(wager.Id, wager, TimeSpan.FromSeconds(20));

            return Ok(new { id = wager.Id, groupName = wager.GroupName, others = others, notification = notification });
        }
    }
}