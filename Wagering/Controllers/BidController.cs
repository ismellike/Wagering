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

        [HttpPost("wager/accept")]
        public async Task<IActionResult> AcceptBid(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }

#nullable disable
            var bid = await _context.WagerHostBids.Include(x => x.Wager).ThenInclude(x => x.Hosts).FirstOrDefaultAsync(x => x.Id == id);
#nullable enable
            if (bid.ProfileId != user.Id)
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
            if (bid.Wager != null)
                if (bid.Wager.IsApproved())
                    await WagerHandler.Confirm(_context, bid.WagerId, user.UserName);
            _context.SaveChanges();
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
            if (bid.ProfileId != user.Id)
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
            await WagerHandler.Decline(_context, bid.WagerId, user.UserName);
            _context.SaveChanges();
            return Ok();
        }
    }
}