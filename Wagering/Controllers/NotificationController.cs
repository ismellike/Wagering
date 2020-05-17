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
            //maybe take x and reload when under n amount on client
            string? userId = User.GetId();
            List<PersonalNotification> notifications = await _context.Notifications.Where(x => x.ProfileId == userId).OrderByDescending(x => x.Date).ToListAsync();
            return Ok(notifications);
        }
    }
}