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
    public class PanelController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PanelController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("client/wagers")]
        public async Task<IActionResult> ClientChallenges()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var requests = await _context.Challenges.Include(x => x.Challengers).Include(x => x.Wager).Where(x => x.Challengers.Any(x => x.UserDisplayName == user.ProfileDisplayName)).ToListAsync();
            return Ok(requests);
        }

        [HttpGet("host/wagers")]
        public async Task<IActionResult> HostWagers()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var requests = await _context.Wagers.Include(x => x.Challenges).ThenInclude(x => x.Challengers).Where(x => x.Hosts.Any(x => x.UserDisplayName == user.ProfileDisplayName)).ToListAsync();
            return Ok(requests);
        }
        
        [HttpPost("host/request")]
        public async Task<IActionResult> SendRequest(int wagerId, string displayName)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User not found.");

            //check if wager belongs to user
            var wager = await _context.Wagers.FindAsync(wagerId);
            if (wager == null)
                return BadRequest("Wager was not found.");
            if (!wager.Hosts.Any(x => x.UserDisplayName == user.ProfileDisplayName))
                return Unauthorized($"{user.ProfileDisplayName} is not authorized to send requests for this wager.");
            //send request to user
            return Ok();
        }
    }
}