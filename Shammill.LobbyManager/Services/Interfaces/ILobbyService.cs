using System;
using System.Collections.Generic;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;

namespace Shammill.LobbyManager.Services.Interfaces
{
    public interface ILobbyService
    {
        Lobby GetLobby(Guid id);
        List<Lobby> GetLobbies(LobbyFilter lobbyFilter);

        Lobby CreateLobby(CreateLobbyRequest lobbyRequest);
        Lobby UpdateLobbyDetails(Lobby lobby);

        void DestroyLobby(Guid lobby);
    }
}
