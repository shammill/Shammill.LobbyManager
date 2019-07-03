using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Hubs;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Services.Interfaces;
using Shammill.LobbyManager.Configuration;

namespace Shammill.LobbyManager.Controllers
{
    [Route("api/[controller]")]
    public class LobbiesController : Controller
    {
        ILobbyService lobbyService;
        IClientNotifier clientNotifier;
        
        public LobbiesController(ILobbyService lobbyService, IClientNotifier clientNotifier)
        {
            this.lobbyService = lobbyService;
            this.clientNotifier = clientNotifier;
        }

#region CRUD
        // GET api/lobbies/{guid}
        [HttpGet("{id}")]
        public Lobby Get(Guid lobbyId)
        {
            return lobbyService.GetLobby(lobbyId);
        }

        // GET api/lobbies
        [HttpGet]
        public IEnumerable<Lobby> Get(LobbyFilter lobbyfilter)
        {
            return lobbyService.GetLobbies(lobbyfilter);
        }


        // POST api/lobbies
        [HttpPost]
        public Lobby Post([FromBody]Lobby lobby)
        {
            if (lobby != null)
                return lobbyService.CreateLobby(lobby);

            else return null;
        }

        // PUT api/lobbies/{guid}
        [HttpPut("{id}")]
        public Lobby Put(Guid id, [FromBody]Lobby lobby)
        {
            lobbyService.UpdateLobby(lobby);

            clientNotifier.LobbyUpdatedNotifyGroup(lobby.Id.ToString(), new HubMessage { data = lobby });

            return lobby;
        }

        // DELETE api/lobbies/{guid}
        [HttpDelete("{lobbyId}")]
        public bool Delete(Guid lobbyId)
        {
            var success = lobbyService.DestroyLobby(lobbyId);

            if (success)
                    clientNotifier.LobbyDeletedNotifyGroup(lobbyId.ToString(), new HubMessage { content = lobbyId.ToString() });

            return true;
        }
#endregion
    }
}
