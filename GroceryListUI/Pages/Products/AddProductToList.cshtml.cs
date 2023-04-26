using GroceryListUI.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace GroceryListUI.Pages.Products
{
    [Authorize]
    public class AddProductToListModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "INSERT INTO ListProduct(ListID, ProductID) VALUES(1,@productid)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@productid", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("/Index");
            }
        }
    }
}
