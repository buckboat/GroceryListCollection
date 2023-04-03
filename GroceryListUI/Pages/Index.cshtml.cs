using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;

namespace GroceryListUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /*
           * 1. Create a SQL connection object
             * 2. Construct a SQL statement
             * 3. Create a SQL command object
             * 4. Open the SQL connection
             * 5. Execute the SQL command
             * 6. Close the SQL connection
        */

        public GroceryListUI.Pages.Models.ListProduct NewListProduct { get; set; } = new GroceryListUI.Pages.Models.ListProduct();

        public void OnGet()
        {
        }
        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                // step 1
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {

                    // step 2
                    string sql = "INSERT INTO ListProduct(ProductID)" + "VALUES(@productId)";
                        //step 3
                        SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@productId", id );



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