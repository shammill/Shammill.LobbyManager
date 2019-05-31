using Shammill.LobbyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shammill.LobbyManager.Persistance
{
    public class LobbyCache
    {
        static LobbyCache _instance = new LobbyCache();

        static LobbyCache()
        {
        }
        LobbyCache()
        {
        }

        public static LobbyCache Instance
        {
            get { return _instance; }
        }

        private Dictionary<Guid, Lobby> _lobbies = new Dictionary<Guid, Lobby>();
        public Dictionary<Guid, Lobby> Lobbies
        {
            get { return _lobbies; }
        }
    }
}
