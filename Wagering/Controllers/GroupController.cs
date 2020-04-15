using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            Profile profile = await _context.GetProfileAsync(User);
            if (profile == null)
                return Unauthorized();
            List<string> groups = new List<string>();
            groups.AddRange(await _context.Wagers.Include(x => x.Hosts).Where(x => x.Hosts.Any(y => y.UserDisplayName == profile.DisplayName)).Select(x => x.GroupName()).ToListAsync());
            return Ok(groups);
        }
    }
}