using System.Threading.Tasks;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public interface IClientNotifier
    {
        Task LobbyCreatedNotifyClient(string connectionId, HubMessage message);
        Task LobbyCreatedNotifyUser(string userId, HubMessage message);
        Task LobbyDeletedNotifyGroup(string group, HubMessage message);
        Task LobbyLeaderChangedNotifyGroup(string group, HubMessage message);
        Task LobbyUpdatedNotifyGroup(string group, HubMessage message);
        Task PlayerAddedToLobbyNotifyClient(string connectionId, HubMessage message);
        Task PlayerAddedToLobbyNotifyGroup(string group, HubMessage message);
        Task PlayerAddedToLobbyNotifyUser(string userId, HubMessage message);
        Task PlayerRemovedFromLobbyNotifyGroup(string userId, HubMessage message);
        Task PlayerRemovedFromLobbyNotifyUser(string userId, HubMessage message);
    }
}