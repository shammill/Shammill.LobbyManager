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
            await Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
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


        [HubMethodName("LobbyCreatedNotifyUser")]
        public async Task LobbyCreatedNotifyUser(string userId, HubMessage message)
        {
            await Clients.User(userId).SendAsync("LobbyCreated", message);
        }

        [HubMethodName("LobbyUpdatedNotifyUser")]
        public async Task LobbyUpdatedNotifyUser(string userId, HubMessage message)
        {
            await Clients.User(userId).SendAsync("LobbyUpdated", message);
        }

        [HubMethodName("LobbyUpdatedNotifyGroup")]
        public async Task LobbyUpdatedNotifyGroup(string group, HubMessage message)
        {
            await Clients.Groups(group).SendAsync("LobbyUpdated", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyUser")]
        public async Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message)
        {
            await Clients.User(userId).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyGroup")]
        public async Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message)
        {
            await Clients.Groups(group).SendAsync("PlayerAddedToLobby", message);
        }


        [HubMethodName("AddUserToGroup")]
        public async Task AddUserToGroup(string userId, string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        [HubMethodName("AddToGroup")]
        public async Task AddToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).SendAsync("AddedToGroup", group);
        }

    }
}
