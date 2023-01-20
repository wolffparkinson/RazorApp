using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task SetEnabled(string value)
        {
            await Clients.All.SendAsync("SetEnabled", value);
        }
    }
}
