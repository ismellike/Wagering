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
    [Authorize]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HostController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("wagers")]
        public async Task<IActionResult> HostWagers()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();

            var requests = await _context.Wagers.Include(x => x.Hosts).ThenInclude(x => x.User).Include(x => x.Challenges).ThenInclude(x => x.Challengers).Where(x => x.Hosts.Any(x => x.UserId == user.Id)).ToListAsync();
            return Ok(requests);
        }
    }
}