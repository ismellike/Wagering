using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Handlers
{
    public static class WagerHandler
    {
        public static async Task<Wager> GetWagerAsync(ApplicationDbContext _context, int wagerId)
        {
            return await _context.Wagers.Where(x => x.Id == wagerId).Include(x => x.Hosts).Include(x => x.Challenges).ThenInclude(x => x.Challengers).FirstOrDefaultAsync();
        }
        public static async Task<List<PersonalNotification>> ConfirmAsync(ApplicationDbContext _context, int wagerId, string? username)
        {
            var wager = await GetWagerAsync(_context, wagerId);
            wager.Status = (byte)Status.Confirmed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has accepted the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            return NotificationHandler.AddNotificationToUsers(_context, wager.AllIds(), notification);
        }

        public static async Task<List<PersonalNotification>> DeclineAsync(ApplicationDbContext _context, int wagerId, string? username)
        {
            var wager = await GetWagerAsync(_context, wagerId);
            wager.Status = (byte)Status.Closed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has declined the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            return NotificationHandler.AddNotificationToUsers(_context, wager.AllIds(), notification);
        }

        public static async Task<List<PersonalNotification>> CloseAsync(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await GetWagerAsync(_context, wagerId);
            wager.Status = (byte)Status.Canceled;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has closed the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            return NotificationHandler.AddNotificationToUsers(_context, wager.AllIds(), notification);
        }

        public static async Task<List<PersonalNotification>> CompleteAsync(ApplicationDbContext _context, int wagerId, string username)
        {
            var wager = await GetWagerAsync(_context, wagerId);
            wager.Status = (byte)Status.Completed;
            PersonalNotification notification = new PersonalNotification
            {
                Date = DateTime.Now,
                Message = $"{username} has completed the wager.",
                Data = wager.Id.ToString(),
                DataModel = (byte)DataModel.Wager
            };
            return NotificationHandler.AddNotificationToUsers(_context, wager.AllIds(), notification);
        }
    }
}