﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Persistance;
using Shammill.LobbyManager.Services.Interfaces;
using Shammill.LobbyManager.Hubs;

namespace Shammill.LobbyManager.Services
{
    public class LobbyService: ILobbyService
    {
        // Will move away from a singleton eventually, HA'd etc.
        Dictionary<Guid, Lobby> lobbies = LobbyCache.Instance.Lobbies;
        private readonly IHubContext<SignalRHub> hubContext;
        private readonly ISignalRHub signalRHub;


        public LobbyService(IHubContext<SignalRHub> hubContext, ISignalRHub signalRHub)
        {
            this.hubContext = hubContext;
            this.signalRHub = signalRHub;
        }

        public Lobby GetLobby(Guid id)
        {
            return lobbies.FirstOrDefault(x => x.Key == id).Value;
        }

        // searching/getting
        public List<Lobby> GetLobbies(LobbyFilter lobbyFilter)
        {
            var filteredLobbies = lobbies.Where(lobby => lobby.Value.Region == lobbyFilter.Region)
                    .Where(lobby => lobby.Value.IsPublic == true)
                    .Where(lobby => lobby.Value.HasGameInProgress == lobbyFilter.HasGameInProgress)
                    .AsQueryable();

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

            // add player who created the lobby to it.

            var user = lobby.Players.First().Id.ToString();

            // add player to signalr lobby group
            signalRHub.AddUserToGroup(user, lobby.Id.ToString());

            // notify user lobby is created
            //var user = hubContext.Clients.Group();
            //var client = hubContext.Clients.
            signalRHub.LobbyCreatedNotifyUser(user.ToString(), new HubMessage { content = lobby });


            return lobby;
        }

        public Lobby UpdateLobby(Lobby lobby)
        {
            lobbies[lobby.Id] = lobby;

            // send an update to all players in this lobby with the changes.
            signalRHub.LobbyUpdatedNotifyGroup(lobby.Id.ToString(), new HubMessage { content = lobby });

            return lobby;
        }

        public void DestroyLobby(Guid lobbyId) {
            lobbies.Remove(lobbyId);
        }
    }
}
