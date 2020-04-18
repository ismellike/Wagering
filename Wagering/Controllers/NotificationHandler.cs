using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    public class NotificationHandler
    {
        private readonly ApplicationDbContext _context;

        public NotificationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendNotifications(IList<Bid> bids, Notification notification)
        {
            List<Notification> notifications = new List<Notification>();
            DateTime date = DateTime.Now;
            foreach (Bid bid in bids)
            {
                if (bid.User == null)
                    continue;
                notifications.Add(new Notification
                {
                    UserId = bid.UserId,
                    Message = notification.Message,
                    Date = date,
                    IsRead = false,
                    Link = notification.Link
                });
            }

            _context.Notifications.AddRange(notifications);
            await _context.SaveChangesAsync();
        }
    }
}
