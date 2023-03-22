using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;

namespace GroceryListUI.Pages.Product
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
             */

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
            // step 1
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {

                // step 2
                string sql = "INSERT INTO Product(ProductName,ImageURL,NutritionLabel,Description,Price,Ingredients,Quantity)" +
                    "VALUES(@productName, @imageURL, @nutritionLabel, @description,@price,@ingredients,@quantity)";
                //step 3
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@productName", NewProduct.ProductName);
                cmd.Parameters.AddWithValue("@imageURl", NewProduct.ImageURL);
                cmd.Parameters.AddWithValue("@nutritionLabel", NewProduct.NutritoinLabel);
                cmd.Parameters.AddWithValue("@description", NewProduct.Description);
                cmd.Parameters.AddWithValue("@price", NewProduct.Price);
                cmd.Parameters.AddWithValue("@ingredients", NewProduct.Ingredients);
                cmd.Parameters.AddWithValue("@quantity", NewProduct.Quantity);
                //step 4
                conn.Open();
                //step 5
                cmd.ExecuteNonQuery();
                //step 6
                conn.Close();

            }

        }
    }
}
