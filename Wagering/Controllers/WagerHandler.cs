using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
    public static class WagerHandler
    {
        public static async Task<PersonalNotification> Confirm(this ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return null;
            wager.Status = (byte)Status.Confirmed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has accepted the wager.",
                Link = wager.GroupLink
            };
            return notification;
        }

        public static async Task<PersonalNotification> Decline(this ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return null;
            wager.Status = (byte)Status.Declined;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has declined the wager.",
                Link = wager.GroupLink
            };
            return notification;
        }

        public static async Task<PersonalNotification> Cancel(this ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return null;
            wager.Status = (byte)Status.Canceled;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has canceled the wager.",
                Link = wager.GroupLink
            };
            return notification;
        }
    }
}