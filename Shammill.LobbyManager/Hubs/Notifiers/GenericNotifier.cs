using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    // These should just be internal ie: not accessible by clients.
    public class GenericNotifier
    {
        SignalRHub SignalRHub;
        public GenericNotifier(SignalRHub signalRHub)
        {
            SignalRHub = signalRHub;
        }

        [HubMethodName("SendMessageToUser")]
        public async Task SendMessageToUser(string userId, HubMessage message)
        {
            await SignalRHub.Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendMessageToGroup")]
        public async Task SendMessageToGroup(string group, HubMessage message)
        {
            await SignalRHub.Clients.Groups(group).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendMessageToAll")]
        public async Task SendMessageToAll(HubMessage message)
        {
            await SignalRHub.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
