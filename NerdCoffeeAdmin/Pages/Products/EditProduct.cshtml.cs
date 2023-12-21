using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NerdCoffeeAdmin.Data;
using NerdCoffeeAdmin.Data.Models;
using System.Linq;

namespace NerdCoffeeAdmin.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private readonly CoffeContext _context;

        [BindProperty]
        public Product Product { get; set; }

        public EditProductModel(CoffeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Product = _context.Products.Find(id);

            if (Product == null)
            {
                return RedirectToPage("/Products/ViewAllProducts");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToPage("/Products/ViewAllProducts");
        }
    }
}