using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Wagering.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wagering.Hubs
{
    [Authorize]
    public class GroupHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public GroupHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public override async Task OnConnectedAsync()
        {
            var id = Context.UserIdentifier;
            var user = await _context.Profiles.Where(x => x.Id == id)
                .Include(x => x.Connections)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                var connection = user.Connections.FirstOrDefault(x => x.ConnectionID == Context.ConnectionId);
                if (connection != null)
                {
                    connection.Connected = true;
                }
                else
                {
                    _context.Connections.Add(new Connection
                    {
                        ProfileId = id,
                        ConnectionID = Context.ConnectionId,
                        UserAgent = Context.GetHttpContext().Request.Headers["User-Agent"],
                        Connected = true
                    });
                }
                _context.SaveChanges();
            }
            await base.OnConnectedAsync();
        }

        public async Task AddToGroup(string id, string groupName)
        {
            var user = await _context.Profiles.AsNoTracking().Where(x => x.Id == id)
                .Include(x => x.Connections)
                .FirstOrDefaultAsync();
            if (user != null)
                foreach (Connection connection in user.Connections)
                    if (connection.Connected)
                        await Groups.AddToGroupAsync(connection.ConnectionID, groupName);
        }

        public async Task RemoveFromGroup(string id, string groupName)
        {
            var user = await _context.Profiles.AsNoTracking().Where(x => x.Id == id)
                .Include(x => x.Connections)
                .FirstOrDefaultAsync();
            if (user != null)
                foreach (Connection connection in user.Connections)
                    if (connection.Connected)
                        await Groups.RemoveFromGroupAsync(connection.ConnectionID, groupName);
        }

        public async Task AddUsersToGroup(string name, string[] ids, PersonalNotification notification)
        {
            var users = await _context.Profiles.AsNoTracking().Where(x => ids.Contains(x.Id))
            .Include(x => x.Connections)
            .ToListAsync();
            foreach (var user in users)
                foreach (var connection in user.Connections)
                    if (connection.Connected)
                        await Clients.Client(connection.ConnectionID).SendAsync("ReceiveGroup", name, notification);
        }

        public async Task NotifyGroup(string name, PersonalNotification notification)
        {
            await Clients.OthersInGroup(name).SendAsync("GetNotification", notification);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connection = await _context.Connections.FindAsync(Context.ConnectionId);
            connection.Connected = false;
            _context.SaveChanges();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
