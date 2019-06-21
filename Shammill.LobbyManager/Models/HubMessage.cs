using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Shammill.LobbyManager.Models
{
    public class HubMessage : Microsoft.AspNetCore.SignalR.Protocol.HubMessage
    {
        public string userId;
        public string content;
        public object data;
    }
}
