using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("wagers")]
        public async Task<IActionResult> HostWagers()
        {
            var profile = await _context.GetProfileAsync(User);
            if (profile == null)
                return Unauthorized();

            var requests = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).Where(x => x.Hosts.Any(x => x.UserDisplayName == profile.DisplayName)).ToListAsync();
            return Ok(requests);
        }
    }
}