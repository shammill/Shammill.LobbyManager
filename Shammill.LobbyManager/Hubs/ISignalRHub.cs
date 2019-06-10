using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Shammill.LobbyManager.Hubs
{
    public interface ISignalRHub
    {

        Task OnConnectedAsync();

        Task OnDisconnectedAsync(Exception exception);


        [HubMethodName("SendMessageToUser")]
        Task SendMessage(string userId, string message);

        [HubMethodName("SendMessageToGroup")]
        Task SendMessageGroup(string group, string message);

        [HubMethodName("SendMessageToAllUsers")]
        Task SendMessageAll(string message);
    }
}
