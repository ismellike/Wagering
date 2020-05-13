using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
                    await WagerHandler.Confirm(_context, bid.WagerId, userName);
            _context.SaveChanges();
            return Ok();
        }

        //decline then send notification to users status => 2
        [HttpPost("wager/decline")]
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
            await WagerHandler.Decline(_context, bid.WagerId, userName);
            _context.SaveChanges();
            return Ok();
        }
    }
}