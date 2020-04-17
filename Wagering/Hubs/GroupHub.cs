using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Wagering.Models;

namespace Wagering.Hubs
{
    [Authorize]
    public class GroupHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public override Task OnConnectedAsync()
        {
            string name = Context.User.FindFirst("name").Value;
            _connections.Add(name, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task AddToGroup(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, name);
        }

        public async Task AddUsersToGroup(string name, string[] usernames, Notification notification)
        {
            foreach (string username in usernames)
                foreach (var connectionId in _connections.GetConnections(username))
                    await Clients.Client(connectionId).SendAsync("ReceiveGroup", name, notification);
        }

        public async Task NotifyGroup(string name, Notification notification)
        {
            await Clients.OthersInGroup(name).SendAsync("GetNotification", notification);
        }

        public async Task RemoveFromGroup(string name)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, name);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.FindFirst("name").Value;
            _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
