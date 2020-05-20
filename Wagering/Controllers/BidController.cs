using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Handlers;
using Wagering.Models;
using Wagering.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BidController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<GroupHub> _hubContext;
        private readonly ErrorMessages _errorMessages = new ErrorMessages { Name = "wager bid" };

        public BidController(ApplicationDbContext context, IHubContext<GroupHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost("wager/accept/{id}")]
        public async Task<IActionResult> AcceptBid(int id)
        {
            string? userId = User.GetId();
            string? userName = User.GetName();

            var bid = await _context.WagerHostBids.Where(x => x.Id == id).Include(x => x.Wager).ThenInclude(x => x.Hosts).FirstOrDefaultAsync();
            if (bid == null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (bid.Wager.Status != (byte)Status.Created)
            {
                ModelState.AddModelError(string.Empty, "Wager is not in the created state.");
                return BadRequest(ModelState);
            }
            if (bid.ProfileId != userId)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotCorresponding);
                return BadRequest(ModelState);
            }
            if (bid.Approved != null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.AlreadySent);
                return BadRequest(ModelState);
            }

            bid.Approved = true;
            if (bid.Wager != null)
                if (bid.Wager.IsApproved())
                {
                    List<PersonalNotification> notifications = await WagerHandler.ConfirmAsync(_context, bid.WagerId, userName);
                    await SignalRHandler.SendNotificationsAsync(_context, _hubContext, notifications.Select(x => x.ProfileId), notifications);
                }
            return Ok();
        }

        [HttpPost("wager/decline/{id}")]
        public async Task<IActionResult> DeclineBid(int id)
        {
            string? userId = User.GetId();
            string? userName = User.GetName();

            var bid = await _context.WagerHostBids.Where(x => x.Id == id).Include(x => x.Wager).FirstOrDefaultAsync();
            if (bid == null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (bid.Wager.Status != (byte)Status.Created)
            {
                ModelState.AddModelError(string.Empty, "Wager is not in the created state.");
                return BadRequest(ModelState);
            }
            if (bid.ProfileId != userId)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotCorresponding);
                return BadRequest(ModelState);
            }
            if (bid.Approved != null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.AlreadySent);
                return BadRequest(ModelState);
            }
            bid.Approved = false;
            List<PersonalNotification> notifications = await WagerHandler.DeclineAsync(_context, bid.WagerId, userName);
            await SignalRHandler.SendNotificationsAsync(_context, _hubContext, notifications.Select(x => x.ProfileId), notifications);
            return Ok();
        }
    }
}