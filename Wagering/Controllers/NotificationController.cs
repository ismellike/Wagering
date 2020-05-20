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
        private readonly ApplicationDbContext _context;
        private readonly ErrorMessages _errorMessages = new ErrorMessages { Name = "notification" };

        public NotificationController(ApplicationDbContext context)
        {
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

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            string? userId = User.GetId();
            PersonalNotification notification = await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (notification == null)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotFound);
                return BadRequest(ModelState);
            }
            if (notification.ProfileId != userId)
            {
                ModelState.AddModelError(string.Empty, _errorMessages.NotCorresponding);
                return BadRequest(ModelState);
            }
            _context.Remove(notification);
            _context.SaveChanges();
            return Ok();
        }
    }
}