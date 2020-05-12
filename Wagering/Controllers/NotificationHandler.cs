using Wagering.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Wagering.Hubs;
using System.Threading.Tasks;

namespace Wagering.Controllers
{
    public static class NotificationHandler
    {
        public static async Task AddNotificationToUsers(ApplicationDbContext _context, IHubContext<GroupHub> _hubContext, IEnumerable<string> UserIds, PersonalNotification notification)
        {
            List<PersonalNotification> notifications = new List<PersonalNotification>();
            foreach (string id in UserIds)
            {
                PersonalNotification personalNotification = new PersonalNotification
                {
                    Date = notification.Date,
                    DataModel = notification.DataModel,
                    Data = notification.Data,
                    Message = notification.Message,
                    ProfileUserId = id
                };
                notifications.Add(personalNotification);
                await _hubContext.Clients.User(id).SendAsync("ReceiveNotification", personalNotification);
            }

            _context.Notifications.AddRange(notifications);
        }
    }
}