using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryListUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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