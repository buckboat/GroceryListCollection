using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;
using Microsoft.AspNetCore.Authorization;

namespace GroceryListUI.Pages.LIstProduct
{
    [Authorize]
    public class CheckoutEditModel : PageModel
    {
        [BindProperty]
        public ListProduct ExistingList { get; set; } = new ListProduct();

        public void OnGet(int Id)
        {
            // step 1
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {

                // step 2
                string sql = "SELECT * FROM LIstProduct WHERE LIstProduct = @productID";
                //step 3
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LIstProduct", Id);

                //step 4
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    reader.Read();
                    ExistingList.ProductQuantity = int.Parse(reader["ListQuantity"].ToString());
                    ExistingList.Discount = (int)decimal.Parse(reader["Discount"].ToString());
                }
            }
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                // step 1
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    // step 2
                    string sql = "UPDATE LIstProduct SET ListQuantity=@listquantity, Discount=@discount WHERE ProductID=@productID";

                    //step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@listquantity", ExistingList.ProductQuantity);
                    cmd.Parameters.AddWithValue("@discount", ExistingList.Discount);
                    cmd.Parameters.AddWithValue("@productID", id);
                    //step 4
                    conn.Open();
                    //step 5
                    cmd.ExecuteNonQuery();
                }
                return RedirectToPage("Checkout");
            }
            else
            {
                return Page();
            }
        }
    }
}


