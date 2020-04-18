using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public BidController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        private async Task Confirm(int wagerId)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = 1;
            // Notify(wager, "Your wager has been confirmed.", $"/host-panel/pending/{wagerId}");
            _context.Wagers.Update(wager);
        }

        private async Task Decline(int wagerId, string name)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = 2;
            // Notify(wager, $"{name} has declined your wager.", $"/host-panel/pending/{wagerId}");
            _context.Wagers.Update(wager);
        }


        [HttpPost("wager/accept")]
        public async Task<IActionResult> AcceptBid(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();
            var bid = await _context.WagerBids.Include(x => x.Wager).ThenInclude(x => x.Hosts).FirstOrDefaultAsync(x => x.Id == id);
            if (bid == null)
            {
                ModelState.AddModelError("Not Found", "The wager bid was not found");
                return BadRequest(ModelState);
            }
            if (bid.UserId != user.Id)
                return Unauthorized();
            if (bid.Approved == null)
            {
                bid.Approved = true;
                if (bid.Wager.IsApproved())
                    await Confirm(bid.WagerId); //add event notification
                _context.WagerBids.Update(bid);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        //decline then send notification to users status => 2
        [HttpPost("wager/decline")]
        public async Task<IActionResult> DeclineBid(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();
            var bid = await _context.WagerBids.FirstOrDefaultAsync(x => x.Id == id);
            if (bid.UserId != user.Id)
                return Unauthorized();
            if (bid == null)
            {
                ModelState.AddModelError("Not Found", "The wager bid was not found");
                return BadRequest(ModelState);
            }
            if (bid.Approved == null)
            {
                bid.Approved = false;
                _context.WagerBids.Update(bid);
                await Decline(bid.WagerId, user.UserName);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}