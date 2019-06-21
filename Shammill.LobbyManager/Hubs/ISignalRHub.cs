using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Hubs.Helpers;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs
{
    public interface ISignalRHub
    {
        GenericNotifier GenericNotifier();
        ClientNotifier ClientNotifier();
        GroupHelper GroupHelper();

        Task OnConnectedAsync();

        Task OnDisconnectedAsync(Exception exception);
    }
}
