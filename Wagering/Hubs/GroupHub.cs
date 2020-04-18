﻿using Microsoft.AspNetCore.Authorization;
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
            _connections.Add(Context.UserIdentifier, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task AddToGroup(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, name);
        }

        public async Task AddUsersToGroup(string name, string[] ids, PersonalNotification notification)
        {
            foreach (string id in ids)
                foreach (var connectionId in _connections.GetConnections(id))
                    await Clients.Client(connectionId).SendAsync("ReceiveGroup", name, notification);
        }

        public async Task NotifyGroup(string name, PersonalNotification notification)
        {
            await Clients.OthersInGroup(name).SendAsync("GetNotification", notification);
        }

        public async Task RemoveFromGroup(string name)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, name);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connections.Remove(Context.UserIdentifier, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
