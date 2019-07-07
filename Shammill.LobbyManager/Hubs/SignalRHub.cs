using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Hubs.Helpers;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Hubs
{
    public class SignalRHub : Hub<ISignalRClient>, ISignalRHub
    {
        ILobbyService lobbyService;
        public SignalRHub(ILobbyService lobbyService) : base()
        {
            this.lobbyService = lobbyService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.Connected(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        [HubMethodName("AddToGroup")]
        public async Task AddToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).AddedToGroup(group);
        }

        [HubMethodName("CreateLobby")]
        public async Task CreateLobby(Lobby lobby)
        {
            if (lobby != null)
                lobbyService.CreateLobby(lobby);

            Groups.AddToGroupAsync(Context.ConnectionId, lobby.Id.ToString());
            await Clients.Groups(lobby.Id.ToString()).LobbyCreated(lobby);
            await Clients.Group(lobby.Id.ToString()).AddedToGroup(lobby.Id.ToString());
        }

        public async Task DeleteLobby(Guid lobbyId)
        {
            var success = lobbyService.DeleteLobby(lobbyId);
            if (success)
                await Clients.Groups(lobbyId.ToString()).LobbyDeleted(lobbyId);
        }
    }
}
