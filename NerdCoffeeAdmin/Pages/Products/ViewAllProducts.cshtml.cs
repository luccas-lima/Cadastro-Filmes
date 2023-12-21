using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NerdCoffeeAdmin.Data;
using NerdCoffeeAdmin.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace NerdCoffeeAdmin.Pages.Products
{
    public class ViewAllProductsModel : PageModel
    {
        private readonly CoffeContext _context;

        public List<Product> Products { get; set; }

        public ViewAllProductsModel(CoffeContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}