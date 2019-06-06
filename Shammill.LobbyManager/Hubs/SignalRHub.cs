using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Shammill.LobbyManager.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.User("").SendAsync(""); //.SendMessage("test");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
