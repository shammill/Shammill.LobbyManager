using System;
using System.Collections.Generic;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;

namespace Shammill.LobbyManager.Services.Interfaces
{
    public interface IPlayerService
    {
        bool AddPlayerToLobby(Guid lobby, Player playerId);
        bool RemovePlayerFromLobby(Guid lobby, Player playerId);
        bool ChangeLobbyLeader(Guid lobby, Player playerId);
    }
}
