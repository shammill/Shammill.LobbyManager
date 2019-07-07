using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Hubs.Helpers;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs
{
    public interface ISignalRHub
    {
        Task OnConnectedAsync();

        Task OnDisconnectedAsync(Exception exception);

        Task CreateLobby(Lobby lobby);
        Task DeleteLobby(Guid lobbyId);
    }
}
