using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryListUI.Pages.Product
{
    public class AddProduct : PageModel
    {
        [BindProperty]

        public GroceryListUI.Pages.Models.Product NewProduct { get; set; } = new GroceryListUI.Pages.Models.Product();
        public void OnGet()
        {
            NewProduct.ProductName = "Name";
            NewProduct.ImageURL = "URL";
            NewProduct.NutritoinLabel = "Nutrition";
            NewProduct.Description = "Description";
            NewProduct.Price = 1.00m;
            NewProduct.Ingredients = "Stuff";
            NewProduct.Quantity = 0;
            

        }

        public void OnPost()
        {

        }
    }
}
