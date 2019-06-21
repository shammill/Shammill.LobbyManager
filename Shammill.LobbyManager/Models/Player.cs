using System;

namespace Shammill.LobbyManager.Models
{
    public class Player
    {
        public Guid Id;
        public string ConnectionId;
        public string Name;
        public bool IsLobbyLeader;
    }
}
