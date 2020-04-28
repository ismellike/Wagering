using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BidController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ErrorMessages _errorMessages = new ErrorMessages { Name = "wager bid" };

        public BidController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        private async Task Confirm(int wagerId, string username)
        {
            var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = 1;
            WagerNotification notification = new WagerNotification
            {
                WagerId = wagerId,
                Notification = new Notification
                {
                    Date = DateTime.Now,
                    Message = $"{username} has accepted the wager."
                }
            };
            _context.WagerNotifications.Add(notification);
            _context.Wagers.Update(wager);
        }

        private async Task Decline(int wagerId, string username)
        {
            var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = 2;
            WagerNotification notification = new WagerNotification
            {
                WagerId = wagerId,
                Notification = new Notification
                {
                    Date = DateTime.Now,
                    Message = $"{username} has declined the wager."
                }
            };
            _context.WagerNotifications.Add(notification);
            _context.Wagers.Update(wager);
        }


        [HttpPost("wager/accept")]
        public async Task<IActionResult> AcceptBid(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }

            var bid = await _context.WagerHostBids.Include(x => x.Wager).ThenInclude(x => x.Hosts).FirstOrDefaultAsync(x => x.Id == id);
            if (bid.UserId != user.Id)
            {
                ModelState.AddModelError("User", _errorMessages.NotCorresponding);
                return BadRequest(ModelState);
            }
            if (bid == null)
            {
                ModelState.AddModelError("Not Found", _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (bid.Approved != null)
            {
                ModelState.AddModelError("Sent", _errorMessages.AlreadySent);
                return BadRequest(ModelState);
            }

            bid.Approved = true;
            if (bid.Wager.IsApproved())
                await Confirm(bid.WagerId, user.UserName);
            _context.WagerHostBids.Update(bid);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //decline then send notification to users status => 2
        [HttpPost("wager/decline")]
        public async Task<IActionResult> DeclineBid(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }

            var bid = await _context.WagerHostBids.FirstOrDefaultAsync(x => x.Id == id);
            if (bid.UserId != user.Id)
            {
                ModelState.AddModelError("User", _errorMessages.NotCorresponding);
                return BadRequest(ModelState);
            }
            if (bid == null)
            {
                ModelState.AddModelError("Not Found", _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (bid.Approved != null)
            {
                ModelState.AddModelError("Sent", _errorMessages.AlreadySent);
                return BadRequest(ModelState);
            }
            bid.Approved = false;
            _context.WagerHostBids.Update(bid);
            await Decline(bid.WagerId, user.UserName);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}