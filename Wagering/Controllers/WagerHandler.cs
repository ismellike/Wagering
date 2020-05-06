using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Controllers
{
  public static class WagerHandler
  {
    public static async Task Confirm(this ApplicationDbContext _context, int wagerId, string username)
    {
      var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
      if (wager == null)
        return;
      wager.Status = (byte)Status.Confirmed;
      WagerNotification notification = new WagerNotification
      {
        WagerId = wagerId,
        Notification = new GroupNotification
        {
          Date = DateTime.Now,
          Message = $"{username} has accepted the wager."
        }
      };
      _context.WagerNotifications.Add(notification);
      _context.Wagers.Update(wager);
    }

    public static async Task Decline(this ApplicationDbContext _context, int wagerId, string username)
    {
      var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
      if (wager == null)
        return;
      wager.Status = (byte)Status.Declined;
      WagerNotification notification = new WagerNotification
      {
        WagerId = wagerId,
        Notification = new GroupNotification
        {
          Date = DateTime.Now,
          Message = $"{username} has declined the wager."
        }
      };
      _context.WagerNotifications.Add(notification);
      _context.Wagers.Update(wager);
    }

    public static async Task Cancel(this ApplicationDbContext _context, int wagerId, string username)
    {
      var wager = await _context.Wagers.FirstOrDefaultAsync(x => x.Id == wagerId);
      if (wager == null)
        return;
      wager.Status = (byte)Status.Canceled;
      WagerNotification notification = new WagerNotification
      {
        WagerId = wagerId,
        Notification = new GroupNotification
        {
          Date = DateTime.Now,
          Message = $"{username} has canceled the wager."
        }
      };
      _context.WagerNotifications.Add(notification);
      _context.Wagers.Update(wager);
    }
  }
}
