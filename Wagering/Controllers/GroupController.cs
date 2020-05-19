using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public GroupController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var userId = User.GetId();
            //join tournamenthostbids etc
            List<string> hostGroups = await _context.WagerHostBids.AsNoTracking().Where(x => x.ProfileId == userId).Select(x => GetGroupName.Wager(x.Id)).ToListAsync();

            List<string> clientGroups = await _context.WagerChallengeBids.AsNoTracking().Where(x => x.ProfileId == userId).Select(x => GetGroupName.Wager(x.Id)).ToListAsync();
            return Ok(new { groups = hostGroups.Union(clientGroups), hostCount = hostGroups.Count, clientCount = clientGroups.Count });
        }
    }
}