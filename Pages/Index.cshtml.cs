using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Models;
using System.Device.Gpio;

namespace RazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int Speed { get; set; }
        public bool Enabled { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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

            // return;
            using(var controller = new GpioController())
            {
                controller.OpenPin(11,PinMode.Output);
                controller.Write(11, fan.Speed);
            }
        }
    }


}