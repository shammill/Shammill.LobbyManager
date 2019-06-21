using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public class ClientNotifier
    {
        SignalRHub SignalRHub;
        public ClientNotifier(SignalRHub signalRHub)
        {
            SignalRHub = signalRHub;
        }

        [HubMethodName("LobbyCreatedNotifyClient")]
        public async Task LobbyCreatedNotifyClient(string connectionId, HubMessage message)
        {
            await SignalRHub.Clients.Client(connectionId).SendAsync("LobbyCreated", message);
        }

        [HubMethodName("LobbyCreatedNotifyUser")]
        public async Task LobbyCreatedNotifyUser(string userId, HubMessage message)
        {
            await SignalRHub.Clients.User(userId).SendAsync("LobbyCreated", message);
        }

        [HubMethodName("LobbyUpdatedNotifyGroup")]
        public async Task LobbyUpdatedNotifyGroup(string group, HubMessage message)
        {
            await SignalRHub.Clients.Groups(group).SendAsync("LobbyUpdated", message);
        }

        [HubMethodName("LobbyDestroyedNotifyGroup")]
        public async Task LobbyDestroyedNotifyGroup(string group, HubMessage message)
        {
            await SignalRHub.Clients.Groups(group).SendAsync("LobbyDestroyed", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyClient")]
        public async Task PlayerAddedToLobbyNotifyClient(string connectionId, HubMessage message)
        {
            await SignalRHub.Clients.Client(connectionId).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyUser")]
        public async Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message)
        {
            await SignalRHub.Clients.User(userId).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyGroup")]
        public async Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message)
        {
            await SignalRHub.Clients.Groups(group).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerRemovedFromLobbyNotifyUser")]
        public async Task PlayerRemovedFromLobbyNotifyUser(string userId, HubMessage message)
        {
            await SignalRHub.Clients.User(userId).SendAsync("PlayerRemovedFromLobby", message);
        }

        [HubMethodName("PlayerRemovedFromLobbyNotifyGroup")]
        public async Task PlayerRemovedFromLobbyNotifyGroup(string userId, HubMessage message)
        {
            await SignalRHub.Clients.User(userId).SendAsync("PlayerRemovedFromLobby", message);
        }
    }
}
