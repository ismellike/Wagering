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
    public class NotificationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private const int ResultSize = 20;

        public NotificationController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("personal")]
        public async Task<IActionResult> GetPersonalNotifications()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return Unauthorized();
            var notifications = await _context.PersonalNotifications.Where(x => x.UserId == user.Id).Take(ResultSize).ToListAsync();
            return Ok(notifications);
        }

        [HttpGet("event/wager/{id}")]
        public async Task<IActionResult> GetEventNotifications(int id)
        {
            var notifications = await _context.EventNotifications.Where(x => x.WagerId == id).ToListAsync();
            return Ok(notifications);
        }
    }
}