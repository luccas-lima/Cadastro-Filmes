using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using NerdCoffeeAdmin.Data;
using NerdCoffeeAdmin.Data.Models;

namespace NerdCoffeeAdmin.Pages
{
    public class HelpModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}
