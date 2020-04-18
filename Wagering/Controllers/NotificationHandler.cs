using System;
using System.Collections.Generic;
using Wagering.Models;

namespace Wagering.Controllers
{
    public static class NotificationHandler
    {
        public static List<PersonalNotification> GetNotifications<T>(ICollection<T> bids, string message, string link) where T: Bid
        {
            List<PersonalNotification> notifications = new List<PersonalNotification>();
            DateTime date = DateTime.Now;
            foreach (Bid bid in bids)
            {
                if (bid.User == null)
                    continue;
                notifications.Add(new PersonalNotification
                {
                    UserId = bid.UserId,
                    Message = message,
                    Date = date,
                    IsRead = false,
                    Link = link
                });
            }
            return notifications;
        }
    }
}
