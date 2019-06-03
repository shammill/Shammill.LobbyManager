using System;
using System.Collections.Generic;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;

namespace Shammill.LobbyManager.Services.Interfaces
{
    public interface ILobbyService
    {
        Lobby CreateLobby(CreateLobbyRequest lobbyRequest);
        void DestroyLobby(Guid lobby);

        Lobby UpdateLobbyDetails(Lobby lobby);

        bool AddPlayerToLobby(Guid lobby, Player playerId);
        bool RemovePlayerFromLobby(Guid lobby, Player playerId);
        bool ChangeLobbyLeader(Guid lobby, Player playerId);

        Lobby GetLobby(Guid id);
        List<Lobby> GetLobbies(LobbyFilter lobbyFilter);
    }
}
