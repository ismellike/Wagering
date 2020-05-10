using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Wagering.Models;
using System.Collections.Generic;

namespace Wagering.Controllers
{
    public static class WagerHandler
    {
        public static async Task Confirm(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = (byte)Status.Confirmed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has accepted the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            _context.AddNotificationToUsers(wager.AllUsers(), notification);
        }

        public static async Task Decline(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            wager.Status = (byte)Status.Declined;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has declined the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            _context.AddNotificationToUsers(wager.AllUsers(), notification);
        }

        public static async Task Cancel(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == wagerId);
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
            _context.AddNotificationToUsers(wager.AllUsers(), notification);
        }

        public static void AddUserGroups(ApplicationDbContext _context, int wagerId, IEnumerable<string> userIds)
        {
            List<UserGroup> userGroups = new List<UserGroup>();
            foreach (string id in userIds)
            {
                userGroups.Add(new UserGroup
                {
                    WagerId = wagerId,
                    UserId = id
                });
            }
            _context.AddRange(userGroups);
        }
    }
}