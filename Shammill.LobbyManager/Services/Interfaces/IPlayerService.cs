using System;
using System.Collections.Generic;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Services.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetPlayers(Guid lobbyId);

        bool AddPlayer(Guid lobbyId, Player player);
        bool RemovePlayer(Guid lobbyId, Player player);
        bool SetLobbyLeader(Guid lobbyId, Player player);
    }
}
