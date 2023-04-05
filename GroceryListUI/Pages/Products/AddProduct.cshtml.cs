using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;

namespace GroceryListUI.Pages.Products
{
    public class AddProduct : PageModel
    {
        [BindProperty]
        public GroceryListUI.Pages.Models.Product NewProduct { get; set; } = new GroceryListUI.Pages.Models.Product();
        public void OnGet()
        {
            /*
             * 1. Create a SQL connection object 
             * 2. Construct a SQL statement
             * 3. Create a SQL command object
             * 4. Open the SQL connection
             * 5. Execute the SQL command
             * 6. Close the SQL connection
             
            
            NewProduct.ProductName = "Name";
            NewProduct.ImageURL = "URL";
            NewProduct.NutrtionLabel = "NutritionURL";
            NewProduct.Description = "Description";
            NewProduct.Price = 0m;
            NewProduct.Ingredient = "Ingredient(s)";
            NewProduct.Quantity = 1;
            */

        }

        private void PopulateProductList()
        {
            using(SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT ProductID, ProductName FROM Product Order by ProductName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   // SelectListItem item = new SelectListItem();




                }
            }
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // step 1
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
               
                    // step 2
                    string sql = "INSERT INTO Product(ProductName,ImageURL,NutrtionLabel,Description,Price,Ingredient,Quantity)" +
                        "VALUES(@productName, @imageURL, @nutrtionLabel, @description,@price,@ingredient,@quantity)";
                    //step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@productName", NewProduct.ProductName);
                    cmd.Parameters.AddWithValue("@imageURl", NewProduct.ImageURL);
                    cmd.Parameters.AddWithValue("@nutrtionLabel", NewProduct.NutrtionLabel);
                    cmd.Parameters.AddWithValue("@description", NewProduct.Description);
                    cmd.Parameters.AddWithValue("@price", NewProduct.Price);
                    cmd.Parameters.AddWithValue("@ingredient", NewProduct.Ingredient);
                    cmd.Parameters.AddWithValue("@quantity", NewProduct.Quantity);
                    
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
