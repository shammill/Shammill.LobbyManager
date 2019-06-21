using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Controllers
{
    [Route("api/lobbies/{lobbyId}/[controller]")]
    public class PlayersController : Controller
    {
        IPlayerService playerService;
        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
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
            return playerService.AddPlayer(lobbyId, player);
        }

        // PUT api/lobbies/{guid}/players/
        [HttpPut("{id}")]
        public bool Put(Guid lobbyId, [FromBody]Player player)
        {
           return playerService.SetLobbyLeader(lobbyId, player);
        }

        // DELETE api/lobbies/{guid}/players
        [HttpDelete("{id}")]
        public bool Delete(Guid lobbyId, Player player)
        {
            return playerService.RemovePlayer(lobbyId, player);
        }

    }
}
