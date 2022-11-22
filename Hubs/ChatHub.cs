using Microsoft.AspNetCore.SignalR;

namespace signalrdersleri.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string message,string name)
        {
            await Clients.All.SendAsync("receiveMessage",message,name);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("connectUser", Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("disconnectUser", Context.ConnectionId);
        }
    }
}
