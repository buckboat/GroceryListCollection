using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;


//crfeate class 



namespace GroceryListUI.Pages
{
    
    

    public class IndexModel : PageModel
    {

        /*
           * 1. Create a SQL connection object
             * 2. Construct a SQL statement
             * 3. Create a SQL command object
             * 4. Open the SQL connection
             * 5. Execute the SQL command
             * 6. Close the SQL connection
        */

        
        public class ProductSearch
        {

            public string SearchBox { get; set; } = string.Empty;

            List<Product>? ProductSearchList { get; set; }

 

        }




        //[BindProperty]
        public List<Product> SearchedProduct { get; set; } = new List<Product>();



        [BindProperty]
        //public string SearchBox;

        public ProductSearch ProductsListMain { get; set; } = new ProductSearch();



        public IActionResult OnGet()
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
                        //producl.Add(product);

                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return Page();
                }
            }

        }


        public IActionResult OnPost(string search)
        {
            if (ModelState.IsValid)
            {
                // step 1
                /*
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {

                    // step 2
                    string sql = "INSERT INTO ListProduct FROM Product WHERE ProductID =@productID";
                        //step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@productId", id );

                    //step 4
                    conn.Open();
                    //step 5
                    cmd.ExecuteNonQuery();
                }
                */
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    // step 2
                    string sql = "SELECT * FROM Product WHERE ProductName ='@SearchBox' Order by ProductName";
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
                            product.SearchBox = reader["SearchBox"].ToString();
                            //SearchedProduct.Add(product);

                        }
                    }

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