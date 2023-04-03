using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;

namespace GroceryListUI.Pages.Products
{
    public class EditProductModel : PageModel
    {
        public Product ExistingProduct { get; set; } = new Product();

        public void OnGet(int Id)
        {
            if (ModelState.IsValid)
            {
                // step 1
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {

                    // step 2
                    string sql = "SELECT * FROM Product WHERE ProductID = @productID";
                    //step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@productID", Id);


                    //step 4
                    conn.Open();
                    //step 5
                    cmd.ExecuteReader();
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
                    string sql = "UPDATE Product SET ProductName=@productName,ImageURL=@imageURL,NutrtionLabel=@nutrtionlabel,Description=@description,Price=@price,Ingredient=@ingredient,Quantity=@quantity WHERE ProductID=@productID";

                    //step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@productName", ExistingProduct.ProductName);
                    cmd.Parameters.AddWithValue("@imageURl", ExistingProduct.ImageURL);
                    cmd.Parameters.AddWithValue("@nutrtionLabel", ExistingProduct.NutrtionLabel);
                    cmd.Parameters.AddWithValue("@description", ExistingProduct.Description);
                    cmd.Parameters.AddWithValue("@price", ExistingProduct.Price);
                    cmd.Parameters.AddWithValue("@ingredient", ExistingProduct.Ingredient);
                    cmd.Parameters.AddWithValue("@quantity", ExistingProduct.Quantity);
                    cmd.Parameters.AddWithValue("@productID", id);
                    //step 4
                    conn.Open();
                    //step 5
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }


        }
    }
}
