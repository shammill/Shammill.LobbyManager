using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs
{
    public class SignalRHub : Hub, ISignalRHub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }


        [HubMethodName("SendMessageToUser")]
        public async Task SendMessage(string userId, HubMessage message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendMessageToGroup")]
        public async Task SendMessageGroup(string group, HubMessage message)
        {
            await Clients.Groups(group).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendMessageToAllUsers")]
        public async Task SendMessageAll(HubMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
