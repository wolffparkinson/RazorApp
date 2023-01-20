using Microsoft.AspNetCore.Mvc;

namespace RazorApp.Models
{
    public class FanModel
    {
        [BindProperty]
        public int Speed { get; set; }

        [BindProperty]
        public bool Enabled { get; set; }

    }
}
