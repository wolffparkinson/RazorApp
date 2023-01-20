using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class FanHub : Hub
    {
        public async Task SetEnabled(string value)
        {
            await Clients.All.SendAsync("SetEnabled", value);
        }
    }
}
