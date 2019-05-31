using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shammill.LobbyManager.Models.Requests
{
    public class LobbyFilter
    {
        public bool IsPublic;
        public bool HasGameInProgress;

        public bool IsNotFull;

        // useful for filters
        public RegionEnum Region;
        public string GameMode;
    }
}
