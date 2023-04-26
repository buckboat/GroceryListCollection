using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryListUI.Pages.Models;


namespace GroceryListUI.Pages.Products
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
