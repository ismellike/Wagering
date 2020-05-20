﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stellar_dotnet_sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Handlers;
using Wagering.Models;
using Wagering.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<GroupHub> _hubContext;
        private readonly Server _server;
        private const int ResultSize = 15;
        private readonly ErrorMessages _errorMessages = new ErrorMessages { Name = "wager" };
        public struct Query
        {
            public int gameId;
            public int page;
            public string? displayName;
            public int? minimumWager;
            public int? maximumWager;
            public int? playerCount;
        }

        public WagerController(ApplicationDbContext context, IHubContext<GroupHub> hubContext, Server server)
        {
            _context = context;
            _server = server;
            _hubContext = hubContext;
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
            if (query.displayName != null)
            {
                query.displayName = query.displayName.ToUpper();
                wagerQuery = wagerQuery.Where(x => x.Hosts.Any(x => x.Profile.NormalizedDisplayName.Contains(query.displayName)));
            }
            PaginatedList<Wager> results = await PaginatedList<Wager>.CreateAsync(wagerQuery.OrderByDescending(x => x.Date), query.page, ResultSize);
            return Ok(results);
        }

        // GET: api/wagers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWager(int id)
        {
            var wager = await _context.Wagers.AsNoTracking().Where(x => x.Id == id).Include(x => x.Hosts).ThenInclude(x => x.Profile).Include(x => x.Challenges).FirstOrDefaultAsync();
            if (wager == null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            return Ok(wager);
        }

        [HttpPost("cancel/{id}")]
        [Authorize]
        public async Task<IActionResult> CancelWager(int id)
        {
            string? userId = User.GetId();
            string? userName = User.GetName();
            Wager wager = await _context.Wagers.Where(x => x.Id == id).Include(x => x.Hosts).FirstOrDefaultAsync();

            if (wager == null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (wager.Status != (byte)Status.Created)
            {
                ModelState.AddModelError(string.Empty, "Wager is not in the created.");
                return BadRequest(ModelState);
            }
            if (!wager.Hosts.Any(x => x.ProfileId == userId))
            {
                ModelState.AddModelError(string.Empty, "You are not a host of this wager.");
                return BadRequest(ModelState);
            }
            wager.Status = (byte)Status.Canceled;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{userName} has canceled the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            List<PersonalNotification> notifications = NotificationHandler.AddNotificationToUsers(_context, wager.HostIds(), notification);
            await SignalRHandler.SendNotificationsAsync(_context, _hubContext, wager.HostIds(), notifications);
            return Ok();
        }

        // POST: api/Wagers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostWager(Wager wagerData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? userId = User.GetId();
            string? userName = User.GetName();
            WagerHostBid caller = wagerData.Hosts.FirstOrDefault(x => x.ProfileId == userId);

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
            //TODO: check sufficient funds on horizon

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
                Message = $"{userName} created a wager with you.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            IEnumerable<string> others = wager.HostIds().Where(x => x != userId);
            List<PersonalNotification> notifications = NotificationHandler.AddNotificationToUsers(_context, others, notification);
            await SignalRHandler.SendNotificationsAsync(_context, _hubContext, others, notifications);
            return Ok(new { id = wager.Id, status = wager.Status });
        }
    }
}