using Microsoft.AspNetCore.Authorization;
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
        private readonly ApplicationDbContext _context;

        public BidController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task Confirm(int wagerId)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).ThenInclude(x => x.Profile).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = 1;
           // Notify(wager, "Your wager has been confirmed.", $"/host-panel/pending/{wagerId}");
            _context.Wagers.Update(wager);
        }

        private async Task Decline(int wagerId, string name)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).ThenInclude(x => x.Profile).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = 2;
           // Notify(wager, $"{name} has declined your wager.", $"/host-panel/pending/{wagerId}");
            _context.Wagers.Update(wager);
        }


        [HttpPost("wager/accept")]
        public async Task<IActionResult> AcceptBid(int id)
        {
            //authorization
            var profile = await _context.GetProfileAsync(User);
            if (profile == null)
                return Unauthorized();
            var bid = await _context.WagerBids.Include(x => x.Wager).ThenInclude(x => x.Hosts).FirstOrDefaultAsync(x => x.Id == id);
            if (bid == null)
            {
                ModelState.AddModelError("Not Found", "The wager bid was not found");
                return BadRequest(ModelState);
            }
            if (bid.ProfileDisplayName != profile.DisplayName)
                return Unauthorized();
            if (bid.Approved == null)
            {
                bid.Approved = true;
                if (bid.Wager.IsApproved())
                    await Confirm(bid.WagerId);
                _context.WagerBids.Update(bid);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        //decline then send notification to users status => 2
        [HttpPost("wager/decline")]
        public async Task<IActionResult> DeclineBid(int id)
        {
            //authorization
            var profile = await _context.GetProfileAsync(User);
            if (profile == null)
                return Unauthorized();
            var bid = await _context.WagerBids.FirstOrDefaultAsync(x => x.Id == id);
            if (bid.ProfileDisplayName != profile.DisplayName)
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
                await Decline(bid.WagerId, profile.DisplayName);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}