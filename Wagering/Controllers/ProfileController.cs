using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/profile/ismellike
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProfile(string name)
        {
            var profile = await _context.Profiles.Include(x => x.Ratings).FirstOrDefaultAsync(x => x.DisplayName == name);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }
    }
}
