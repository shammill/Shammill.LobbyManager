using System;
using System.Threading.Tasks;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public interface ISignalRClient
    {
        Task Connected(string connectionId);
        Task AddedToGroup(string group);

        Task LobbyCreated(Lobby lobby);
        Task LobbyDeleted(Guid success);
    }
}