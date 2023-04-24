using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;
using Microsoft.AspNetCore.Authorization;

namespace GroceryListUI.Pages.Products
{
    //[Authorize]
    public class DeleteProductModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "DELETE FROM Product WHERE ProductID = @productid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@productid", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("Index");
            }
        }
    }
}
