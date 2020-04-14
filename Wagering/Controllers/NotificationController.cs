using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Wagering.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private const int ResultSize = 20;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var profile = await _context.GetProfileAsync(User);
            if (profile == null)
                return Unauthorized();
            var notifications = await _context.Notifications.Where(x => x.ProfileId == profile.Id).Take(ResultSize).ToListAsync();
            return Ok(notifications);
        }
    }
}