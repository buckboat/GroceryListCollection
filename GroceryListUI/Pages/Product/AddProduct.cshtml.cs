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
            SqlConnection conn = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=Grocery;Trusted_Connection=true;");
            // step 2
            string sql = "INSERT INTO Product(ProductName,ImageURL,NutritionLabel,Description,Price,Ingredients,Quantity)" +
                "VALUES('" + NewProduct.ProductName +"','"+ NewProduct.ImageURL+"','" + NewProduct.Price + "','" + NewProduct.Description +
                "','" + NewProduct.Price + "','" + NewProduct.Ingredients + "','" + NewProduct.Quantity + "')";
            //step 3
            SqlCommand cmd = new SqlCommand(sql,conn);
            //step 4
            conn.Open();
            //step 5
            cmd.ExecuteNonQuery();
            //step 6
            conn.Close();
 


        }
    }
}
