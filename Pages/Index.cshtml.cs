using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using RazorApp.Models;
using SignalRChat.Hubs;
using System.Device.Gpio;

namespace RazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHubContext<SignalRHub> _hubContext;

        public int Speed { get; set; }
        public bool Enabled { get; set; }


        public IndexModel(IHubContext<SignalRHub> hubContext)
        {
            _hubContext = hubContext;
        }


        public void OnGet()
        {

        }

        public void OnPostSubmit(GPIO17Model gpIo17)
        {
            this.Speed = gpIo17.Speed;
            this.Enabled= gpIo17.Enabled;

            Console.WriteLine($"Speed : {this.Speed}s");
            Console.WriteLine($"Enabled : {this.Enabled}");

            // return;
            using(var controller = new GpioController())
            {
                controller.OpenPin(11,PinMode.Output);
                controller.Write(11, PinValue.High);
            }
            _hubContext.Clients.All.SendAsync("SetEnabled", this.Enabled);
        }
    }


}