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
        private readonly ILogger<IndexModel> _logger;
        private readonly IHubContext<FanHub> _hubContext;

        public int Speed { get; set; }
        public bool Enabled { get; set; }


        public IndexModel(ILogger<IndexModel> logger,IHubContext<FanHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }


        public void OnGet()
        {

        }

        public void OnPostSubmit(FanModel fan)
        {
            this.Speed = fan.Speed;
            this.Enabled= fan.Enabled;

            Console.WriteLine($"Speed : {this.Speed}s");
            Console.WriteLine($"Enabled : {this.Enabled}");

            _hubContext.Clients.All.SendAsync("SetEnabled", this.Enabled);
            // return;
            using(var controller = new GpioController())
            {
                controller.OpenPin(11,PinMode.Output);
                controller.Write(11, fan.Speed);
            }
        }
    }


}