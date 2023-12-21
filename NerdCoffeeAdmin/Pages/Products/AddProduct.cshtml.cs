using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NerdCoffeeAdmin.Data;
using NerdCoffeeAdmin.Data.Models;

namespace NerdCoffeeAdmin.Pages.Products
{
    public class AddproductModel : PageModel
    {
        private CoffeContext context;
        private IWebHostEnvironment env;

        [BindProperty]
        public Product NewProduct { get; set; }

        [BindProperty]
        public string Description { get; set; } 

        public void OnGet()
        {
        }

        public AddproductModel(CoffeContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

            if (NewProduct.Upload is not null)
            {
                NewProduct.ImageFileName = NewProduct.Upload.FileName;

                var file = Path.Combine(env.ContentRootPath, "wwwroot/images/menu",
                    NewProduct.Upload.FileName);

                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    NewProduct.Upload.CopyTo(filestream);
                }
            }
            NewProduct.Created = DateTime.Now;
            context.Products.Add(NewProduct);
            context.SaveChanges();
            return RedirectToPage("ViewAllProducts");
        }
    }
}