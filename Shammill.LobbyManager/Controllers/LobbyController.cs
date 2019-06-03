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
    [Route("api/[controller]")]
    public class LobbyController : Controller
    {
        ILobbyService lobbyService;
        public LobbyController(ILobbyService lobbyService)
        {
            this.lobbyService = lobbyService;
        }

        // GET api/lobby/5
        [HttpGet("{id}")]
        public Lobby Get(Guid lobbyId)
        {
            return lobbyService.GetLobby(lobbyId);
        }

        // GET api/lobby
        [HttpGet]
        public IEnumerable<Lobby> Get(LobbyFilter lobbyfilter)
        {
            return lobbyService.GetLobbies(lobbyfilter);
        }


        // POST api/lobby
        [HttpPost]
        public Lobby Post([FromBody]CreateLobbyRequest createLobbyRequest)
        {
            return lobbyService.CreateLobby(createLobbyRequest);
        }

        // PUT api/lobby/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Lobby lobby)
        {
            lobbyService.UpdateLobbyDetails(lobby);
        }

        // DELETE api/lobby/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            lobbyService.DestroyLobby(id);
        }
    }
}
