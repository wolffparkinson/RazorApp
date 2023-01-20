using Microsoft.AspNetCore.Mvc;

namespace RazorApp.Models
{
    public class GPIO17Model
    {
        [BindProperty]
        public int Speed { get; set; }

        [BindProperty]
        public bool Enabled { get; set; }

    }
}
