using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryListUI.Pages.Products;
using GroceryListUI.Pages.Models;
using Microsoft.Data.SqlClient;

namespace GroceryListUI.Pages.Products
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> ProductsList { get; set; } = new List<Product>();


        public void OnGet()
        {
            // step 1
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                // step 2
                string sql = "SELECT * FROM Product Order by ProductName";
                //step 3
                SqlCommand cmd = new SqlCommand(sql, conn);            
                //step 4
                conn.Open();
                //step 5
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Product product = new Product();
                        product.ProductID = int.Parse(reader["ProductID"].ToString());
                        product.ProductName = reader["ProductName"].ToString();
                        product.ImageURL = reader["ImageURL"].ToString();
                        product.NutrtionLabel = reader["NutrtionLabel"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = decimal.Parse(reader["Price"].ToString());
                        product.Ingredient = reader["Ingredient"].ToString();
                        product.Quantity = int.Parse(reader["Quantity"].ToString());
                        ProductsList.Add(product);
                    }
                }
            }

        }
    }
}