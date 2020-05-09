using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Wagering.Models;
using System.Linq;

namespace Wagering.Controllers
{
    public static class WagerHandler
    {
        public static async Task<PersonalNotification> Confirm(this ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Challenges).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return null;
            wager.Status = (byte)Status.Confirmed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has accepted the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            return notification;
        }

        public static async Task<PersonalNotification> Decline(this ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Challenges).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return null;
            wager.Status = (byte)Status.Declined;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has declined the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            return notification;
        }

        public static async Task Cancel(this ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Challenges).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = (byte)Status.Canceled;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has canceled the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            _context.AddNotificationToUsers(wager.Hosts.Select(x => x.UserId).Union(wager.Challenges.Select(x => x.Challengers.UserId)), notification);
        }
    }
}