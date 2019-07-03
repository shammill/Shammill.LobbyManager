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

        public async Task LobbyCreatedNotifyClient(string connectionId, HubMessage message)
        {
            await HubContext.Clients.Client(connectionId).SendAsync("LobbyCreated", message);
        }

        public async Task LobbyCreatedNotifyUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("LobbyCreated", message);
        }

        public async Task LobbyUpdatedNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("LobbyUpdated", message);
        }

        public async Task LobbyDeletedNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("LobbyDeleted", message);
        }

        public async Task PlayerAddedToLobbyNotifyClient(string connectionId, HubMessage message)
        {
            await HubContext.Clients.Client(connectionId).SendAsync("PlayerAddedToLobby", message);
        }

        public async Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerAddedToLobby", message);
        }

        public async Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("PlayerAddedToLobby", message);
        }

        public async Task PlayerRemovedFromLobbyNotifyUser(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerRemovedFromLobby", message);
        }

        public async Task PlayerRemovedFromLobbyNotifyGroup(string userId, HubMessage message)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerRemovedFromLobby", message);
        }

        public async Task LobbyLeaderChangedNotifyGroup(string group, HubMessage message)
        {
            await HubContext.Clients.Groups(group).SendAsync("PlayerPromotedToLeader", message);
        }
    }
}
