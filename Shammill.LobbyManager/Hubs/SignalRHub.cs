using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Models;
using Shammill.LobbyManager.Hubs.Helpers;
using Shammill.LobbyManager.Hubs.Notifiers;

namespace Shammill.LobbyManager.Hubs
{
    public class SignalRHub : Hub
    {
        public GroupHelper GroupHelper;

        public SignalRHub() : base()
        {
            GroupHelper = new GroupHelper(this);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }


        [HubMethodName("AddToGroup")]
        public async Task AddToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).SendAsync("AddedToGroup", group);
        }

    }
}
