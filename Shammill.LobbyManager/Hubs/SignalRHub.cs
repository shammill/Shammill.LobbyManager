using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Shammill.LobbyManager.Hubs
{
    public class SignalRHub : Hub
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
        public async Task SendMessage(string user, string message)
        {
            await Clients.User("").SendAsync(""); //.SendMessage("test");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
