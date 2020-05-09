using Wagering.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public NotificationController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                ModelState.AddModelError("Unauthorized", ErrorMessages.Unauthorized);
                return BadRequest(ModelState);
            }

            List<PersonalNotification> notifications = await _context.Notifications.Where(x => x.UserId == user.Id).ToListAsync();
            return Ok(notifications);
        }
    }
}