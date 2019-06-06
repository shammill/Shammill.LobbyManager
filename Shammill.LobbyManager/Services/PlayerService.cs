using System;
using System.Collections.Generic;
using System.Linq;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Persistance;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Services
{
    public class PlayerService : IPlayerService
    {
        // Will move away from a singleton eventually, HA'd etc.
        Dictionary<Guid, Lobby> lobbies = LobbyCache.Instance.Lobbies;

        public PlayerService()
        {
            
        }

        public List<Player> GetPlayers(Guid lobbyId)
        {
            return lobbies[lobbyId].Players;
        }

        public bool AddPlayer(Guid lobbyId, Player player) {
            lobbies[lobbyId].Players.Add(player);
            return true;
        }

        public bool RemovePlayer(Guid lobbyId, Player player) {
            lobbies[lobbyId].Players.Remove(player);
            return true;
        }

        public bool SetLobbyLeader(Guid lobbyId, Player playerLeader) {
            var isSuccessful = false;
            foreach (var player in lobbies[lobbyId].Players)
            {
                if (player.Id == playerLeader.Id)
                {
                    player.IsLobbyLeader = true;
                    isSuccessful = true;
                }
                else
                {
                    player.IsLobbyLeader = false;
                }
            }
            return isSuccessful;
        }
    }
}
