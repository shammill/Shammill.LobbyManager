using Shammill.LobbyManager.Models;
using System;
using System.ComponentModel;

namespace Shammill.LobbyManager.Utilities
{
    public static class Configuration
    {
        // Two ways of notifying users, can choose.
        public static bool NotifyConnectionIds { get; set; } = true;
        public static bool NotifyUserIds { get; set; } = true;
    }
}
