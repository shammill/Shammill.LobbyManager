using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public class GenericNotifier : IGenericNotifier
    {
        IHubContext<SignalRHub> HubContext;
        public GenericNotifier(IHubContext<SignalRHub> hubContext)
        {
            HubContext = hubContext;
        }

        [HubMethodName("SendMessageToUser")]
        public async Task SendMessageToUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendMessageToGroup")]
        public async Task SendMessageToGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendMessageToAll")]
        public async Task SendMessageToAll(HubMessage message)
        {
            await HubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
