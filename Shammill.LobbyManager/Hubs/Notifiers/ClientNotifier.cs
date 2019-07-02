using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public class ClientNotifier : IClientNotifier
    {
        IHubContext<SignalRHub> HubContext;
        public ClientNotifier(IHubContext<SignalRHub> hubContext)
        {
            HubContext = hubContext;
        }

        [HubMethodName("LobbyCreatedNotifyClient")]
        public async Task LobbyCreatedNotifyClient(string connectionId, HubMessage message)
        {
            await HubContext.Clients.Client(connectionId).SendAsync("LobbyCreated", message);
        }

        [HubMethodName("LobbyCreatedNotifyUser")]
        public async Task LobbyCreatedNotifyUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("LobbyCreated", message);
        }

        [HubMethodName("LobbyUpdatedNotifyGroup")]
        public async Task LobbyUpdatedNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("LobbyUpdated", message);
        }

        [HubMethodName("LobbyDeletedNotifyGroup")]
        public async Task LobbyDeletedNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("LobbyDeleted", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyClient")]
        public async Task PlayerAddedToLobbyNotifyClient(string connectionId, HubMessage message)
        {
            await HubContext.Clients.Client(connectionId).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyUser")]
        public async Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerAddedToLobbyNotifyGroup")]
        public async Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("PlayerAddedToLobby", message);
        }

        [HubMethodName("PlayerRemovedFromLobbyNotifyUser")]
        public async Task PlayerRemovedFromLobbyNotifyUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerRemovedFromLobby", message);
        }

        [HubMethodName("PlayerRemovedFromLobbyNotifyGroup")]
        public async Task PlayerRemovedFromLobbyNotifyGroup(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerRemovedFromLobby", message);
        }

        [HubMethodName("LobbyLeaderChangedNotifyGroup")]
        public async Task LobbyLeaderChangedNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("PlayerPromotedToLeader", message);
        }
    }
}
