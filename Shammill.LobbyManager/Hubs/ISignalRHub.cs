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

        [HubMethodName("LobbyCreatedNotifyUser")]
        Task LobbyCreatedNotifyUser(string userId, HubMessage message);

        [HubMethodName("LobbyUpdatedNotifyUser")]
        Task LobbyUpdatedNotifyUser(string userId, HubMessage message);

        [HubMethodName("LobbyUpdatedNotifyGroup")]
        Task LobbyUpdatedNotifyGroup(string group, HubMessage message);

        [HubMethodName("PlayerAddedToLobbyNotifyUser")]
        Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message);

        [HubMethodName("PlayerAddedToLobbyNotifyGroup")]
        Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message);

        Task AddUserToGroup(string userid, string group);

        Task AddToGroup(string group);
    }
}
