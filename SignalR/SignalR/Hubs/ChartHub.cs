using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class ChartHub : Hub
    {

        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("RecieveMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("UserDisConnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
