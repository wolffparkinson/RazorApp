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

//using Microsoft.AspNetCore.SignalR;

//namespace MyApp.Namespace
//{
//    public interface IOutput
//    {
//        Task OutputChanged(bool value);
//    }

//    public class OutputHub : Hub<IOutput>
//    {

//        public OutputHub()
//        {
//            Console.WriteLine("OutputHub created");
//        }

//        public async Task OutputChanged(bool value)
//        {
//            Console.WriteLine($"OutputChanged: {value}");
//            await Clients.All.OutputChanged(value);
//        }
//    }
//}