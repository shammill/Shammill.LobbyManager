using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs
{
    public interface ISignalRHub
    {

        Task OnConnectedAsync();

        Task OnDisconnectedAsync(Exception exception);


        [HubMethodName("SendMessageToUser")]
        Task SendMessage(string userId, HubMessage message);

        [HubMethodName("SendMessageToGroup")]
        Task SendMessageGroup(string group, HubMessage message);

        [HubMethodName("SendMessageToAllUsers")]
        Task SendMessageAll(HubMessage message);
    }
}
