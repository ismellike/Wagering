using System;
using System.Collections.Generic;
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

        public void SendNotifications(IList<Bid> bids)
        {
            DateTime time = DateTime.Now;
        }
    }
}
