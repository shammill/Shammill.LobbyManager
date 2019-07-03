using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Configuration;
using Shammill.LobbyManager.Hubs;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Controllers
{
    [Route("api/lobbies/{lobbyId}/[controller]")]
    public class PlayersController : Controller
    {
        IPlayerService playerService;
        private readonly IClientNotifier clientNotifier;
        public PlayersController(IPlayerService playerService, IClientNotifier clientNotifier)
        {
            this.playerService = playerService;

            if (Config.SignalREnabled)
                this.clientNotifier = clientNotifier;
            else
                this.clientNotifier = new DisabledClientNotifier();
        }

        // GET api/lobbies/{guid}/players/
        [HttpGet("{id}")]
        public List<Player> Get(Guid lobbyId)
        {
            return playerService.GetPlayers(lobbyId);
        }

        // POST api/lobbies/{guid}/players/
        [HttpPost]
        public bool Post([FromRoute]Guid lobbyId, [FromBody]Player player)
        {
            var success = playerService.AddPlayer(lobbyId, player);
            if (success)
                clientNotifier.PlayerAddedToLobbyNotifyGroup(lobbyId.ToString(), new HubMessage { data = player });

            return success;

        }

        // PUT api/lobbies/{guid}/players/
        [HttpPut("{id}")]
        public bool Put(Guid lobbyId, [FromBody]Player player)
        {
            var success = playerService.SetLobbyLeader(lobbyId, player);
            if (success)
                clientNotifier.LobbyLeaderChangedNotifyGroup( lobbyId.ToString(), new HubMessage { data = player });

            return success;
        }

        // DELETE api/lobbies/{guid}/players
        [HttpDelete("{id}")]
        public bool Delete(Guid lobbyId, Player player)
        {
            var success = playerService.RemovePlayer(lobbyId, player);

            if (success)
                clientNotifier.PlayerRemovedFromLobbyNotifyGroup(lobbyId.ToString(), new HubMessage { data = player });

            return success;
        }

    }
}
