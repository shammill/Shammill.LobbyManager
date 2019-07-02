using System.Threading.Tasks;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public interface IGenericNotifier
    {
        Task SendMessageToAll(HubMessage message);
        Task SendMessageToGroup(string group, HubMessage message);
        Task SendMessageToUser(string userId, HubMessage message);
    }
}