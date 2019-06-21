using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;

namespace Shammill.LobbyManager.Hubs.Helpers
{
    public class GroupHelper
    {
        SignalRHub SignalRHub;
        public GroupHelper(SignalRHub signalRHub)
        {
            SignalRHub = signalRHub;
        }

        public async Task AddConnectionToGroup(string connectionId, string group)
        {
            await SignalRHub.Groups.AddToGroupAsync(connectionId, group);
        }

        public async Task RemoveConnectionFromGroup(string connectionId, string group)
        {
            await SignalRHub.Groups.RemoveFromGroupAsync(connectionId, group);
        }
    }
}
