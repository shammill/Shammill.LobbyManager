using System.Threading.Tasks;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    // just testing a way of disabling a feature without having "isEnabled" flags through code.
    public class DisabledClientNotifier : IClientNotifier
    {
        public DisabledClientNotifier()
        {
           
        }

        public Task LobbyCreatedNotifyClient(string connectionId, HubMessage message)
        {
            return null;
        }

        public Task LobbyCreatedNotifyUser(string userId, HubMessage message)
        {
            return null;
        }

        public Task LobbyUpdatedNotifyGroup(string group, HubMessage message)
        {
            return null;
        }

        public Task LobbyDeletedNotifyGroup(string group, HubMessage message)
        {
            return null;
        }

        public Task PlayerAddedToLobbyNotifyClient(string connectionId, HubMessage message)
        {
            return null;
        }

        public Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message)
        {
            return null;
        }

        public Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message)
        {
            return null;
        }

        public Task PlayerRemovedFromLobbyNotifyUser(string userId, HubMessage message)
        {
            return null;
        }

        public Task PlayerRemovedFromLobbyNotifyGroup(string userId, HubMessage message)
        {
            return null;
        }

        public Task LobbyLeaderChangedNotifyGroup(string group, HubMessage message)
        {
            return null;
        }
    }
}
