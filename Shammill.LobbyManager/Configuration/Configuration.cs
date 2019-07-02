namespace Shammill.LobbyManager.Configuration
{
    public static class Config
    {
        // Two ways of notifying users, can choose.
        public static bool NotifyConnectionIds { get; set; } = true;
        public static bool NotifyUserIds { get; set; } = true;

        public static bool SignalREnabled { get; set; } = true;
    }
}
