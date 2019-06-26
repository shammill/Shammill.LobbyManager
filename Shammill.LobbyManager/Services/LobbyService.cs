using System;
using System.Collections.Generic;
using System.Linq;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Persistance;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Services
{
    public class LobbyService: ILobbyService
    {
        // Will move away from a singleton eventually, HA'd or DB etc.
        Dictionary<Guid, Lobby> lobbies = LobbyCache.Instance.Lobbies;

        public LobbyService()
        {

        }

        public Lobby GetLobby(Guid id)
        {
            return lobbies.FirstOrDefault(x => x.Key == id).Value;
        }

        // searching/getting
        public List<Lobby> GetLobbies(LobbyFilter lobbyFilter)
        {
            var filteredLobbies = lobbies
                    .Where(lobby => lobby.Value.IsPublic == true)
                    .Where(lobby => lobby.Value.HasGameInProgress == lobbyFilter.HasGameInProgress)
                    .AsQueryable();

            if (lobbyFilter.Region == RegionEnum.Unspecified)
                filteredLobbies = filteredLobbies.Where(lobby => lobby.Value.Region == lobbyFilter.Region);

            if (lobbyFilter.IsNotFull)
            {
                filteredLobbies = filteredLobbies.Where(x => x.Value.Players.Count < x.Value.MaximumSize);
            }

            return filteredLobbies
                    .Select(x => x.Value)
                    .ToList();
        }

        public Lobby CreateLobby(Lobby lobby)
        {
            lobby.Id = Guid.NewGuid();
            lobbies.Add(lobby.Id, lobby);

            return lobby;
        }

        public Lobby UpdateLobby(Lobby lobby)
        {
            lobbies[lobby.Id] = lobby;

            return lobby;
        }

        public bool DestroyLobby(Guid lobbyId) {
            var success = lobbies.Remove(lobbyId);
            return success;
        }
    }
}
