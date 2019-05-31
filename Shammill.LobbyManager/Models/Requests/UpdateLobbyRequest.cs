using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shammill.LobbyManager.Models.Requests
{
    public class UpdateLobbyRequest
    {
        public string Name;

        public int MaximumSize;
        public bool IsPublic;
        public bool IsJoinable;
        public bool HasGameInProgress;

        // useful for filters
        public RegionEnum Region;
        public string GameMode;
    }
}
