using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Wagering.Models;
using System.Collections.Generic;
using System.Linq;

namespace Wagering.Controllers
{
    public static class WagerHandler
    {
        public static async Task Confirm(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Where(x => x.Id == wagerId).Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync();
            if (wager == null)
                return;
            Confirm(_context, wager, username);
        }

        public static void Confirm(ApplicationDbContext _context, Wager wager, string username)
        {
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
            Decline(_context, wager, username);
        }
        public static void Decline(ApplicationDbContext _context, Wager wager, string username)
        {
            wager.Status = (byte)Status.Closed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has declined the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            _context.AddNotificationToUsers(wager.AllUsers(), notification);
        }

        public static async Task Close(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            Close(_context, wager, username);
        }

        public static void Close(ApplicationDbContext _context, Wager wager, string username)
        {
            wager.Status = (byte)Status.Canceled;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has closed the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            _context.AddNotificationToUsers(wager.AllUsers(), notification);
        }

        public static async Task Complete(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await _context.Wagers.Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync(x => x.Id == wagerId);
            if (wager == null)
                return;
            Complete(_context, wager, username);
        }

        public static void Complete(ApplicationDbContext _context, Wager wager, string username)
        {
            if (wager == null)
                return;
            wager.Status = (byte)Status.Completed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has completed the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            _context.AddNotificationToUsers(wager.AllUsers(), notification);
        }

        private static async Task<Wager> GetWagerAsync(ApplicationDbContext _context, int wagerId)
        {
            return await _context.Wagers.Where(x => x.Id == wagerId).Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync();
        }

        public static void AddUserGroups(ApplicationDbContext _context, int wagerId, IEnumerable<string?> userIds)
        {
            List<UserGroup> userGroups = new List<UserGroup>();
            foreach (string? id in userIds)
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