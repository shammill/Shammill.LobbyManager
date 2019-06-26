using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shammill.LobbyManager.Hubs;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Controllers
{
    [Route("api/[controller]")]
    public class LobbiesController : Controller
    {
        ILobbyService lobbyService;
        private readonly SignalRHub signalRHub;

        public LobbiesController(ILobbyService lobbyService, SignalRHub signalRHub)
        {
            this.lobbyService = lobbyService;
            this.signalRHub = signalRHub;
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

            signalRHub.ClientNotifier.LobbyUpdatedNotifyGroup(lobby.Id.ToString(), new HubMessage { data = lobby });

            return lobby;
        }

        // DELETE api/lobbies/{guid}
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var success = lobbyService.DestroyLobby(id);

            if (success)
                signalRHub.ClientNotifier.LobbyDestroyedNotifyGroup(id.ToString(), new HubMessage { content = id.ToString() });

            return true;
        }
#endregion
    }
}
