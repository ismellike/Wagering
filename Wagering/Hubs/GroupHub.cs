using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Wagering.Hubs
{
    public class GroupHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task AddToGroup(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, name);
        }
        public async Task NotifyGroup(string name, string message)
        {
            await Clients.OthersInGroup(name).SendAsync("GetNotification", message);
        }
        public async Task RemoveFromGroup(string name)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, name);
        }
    }
}
