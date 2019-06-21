using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Models.Requests;
using Shammill.LobbyManager.Services.Interfaces;

namespace Shammill.LobbyManager.Controllers
{
    [Route("api/[controller]")]
    public class LobbiesController : Controller
    {
        ILobbyService lobbyService;
        public LobbiesController(ILobbyService lobbyService)
        {
            this.lobbyService = lobbyService;
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
            //var stream = new StreamReader(Request.Body);
            //var body = stream.ReadToEnd();
            //Console.WriteLine(body);
            if (lobby != null)
                return lobbyService.CreateLobby(lobby);

            else return null;
        }

        // PUT api/lobbies/{guid}
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Lobby lobby)
        {
            lobbyService.UpdateLobby(lobby);
        }

        // DELETE api/lobbies/{guid}
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            lobbyService.DestroyLobby(id);
        }
#endregion


    }
}
