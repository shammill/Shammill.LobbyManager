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
    [Route("api/lobbies/{id}/[controller]")]
    public class PlayersController : Controller
    {
        IPlayerService playerService;
        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        // GET api/lobbies/{guid}
        [HttpGet("{id}")]
        public List<Player> Get(Guid lobbyId)
        {
            return new List<Player>(); //todo //playerService.(lobbyId);
        }

        // POST api/lobbies/{guid}/players/
        [HttpPost]
        public bool Post([FromQuery]Guid lobbyId, [FromBody]Player addPlayerRequest)
        {
            return playerService.AddPlayerToLobby(lobbyId, addPlayerRequest);
        }

        // PUT api/lobbies/{guid}/players/
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody]Player player)
        {
           return playerService.ChangeLobbyLeader(id, player);
        }

        // DELETE api/lobbies/{guid}
        [HttpDelete("{id}")]
        public bool Delete(Guid id, Player playerId)
        {
            return playerService.RemovePlayerFromLobby(id, playerId);
        }

    }
}
