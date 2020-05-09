using Wagering.Models;
using System.Collections.Generic;

namespace Wagering.Controllers
{
    public static class NotificationHandler
    {
        public static void AddNotificationToUsers(this ApplicationDbContext _context, IEnumerable<string> UserIds, PersonalNotification notification)
        {
            List<PersonalNotification> notifications = new List<PersonalNotification>();
            foreach (string id in UserIds)
            {
                notifications.Add(new PersonalNotification
                {
                    Date = notification.Date,
                    DataModel = notification.DataModel,
                    Data = notification.Data,
                    Message = notification.Message,
                    UserId = id
                });
            }

            _context.Notifications.AddRange(notifications);
        }
    }
}