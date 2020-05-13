using Wagering.Models;
using System.Collections.Generic;

namespace Wagering.Controllers
{
    public static class NotificationHandler
    {
        public static void AddNotificationToUsers(ApplicationDbContext _context, IEnumerable<string> userIds, PersonalNotification notification)
        {
            List<PersonalNotification> notifications = new List<PersonalNotification>();
            foreach (string id in userIds)
            {
                PersonalNotification personalNotification = new PersonalNotification
                {
                    Date = notification.Date,
                    DataModel = notification.DataModel,
                    Data = notification.Data,
                    Message = notification.Message,
                    ProfileId = id
                };
                notifications.Add(personalNotification);
            }

            _context.Notifications.AddRange(notifications);
        }
    }
}