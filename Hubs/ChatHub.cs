using Microsoft.AspNetCore.SignalR;

namespace signalrdersleri.Hubs
{
    public class ChatHub:Hub
    {
        private static List<string> Users = new List<string>();
        public async Task SendMessage(string message,string name)
        {
            await Clients.All.SendAsync("receiveMessage",message,name);
        }
        public override async Task OnConnectedAsync()
        {
            Users.Add(Context.ConnectionId);
            await Clients.All.SendAsync("connectUser", Context.ConnectionId);
            await Clients.All.SendAsync("Users", Users);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Users.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("disconnectUser", Context.ConnectionId);
            await Clients.All.SendAsync("Users", Users);
        }
    }
}
