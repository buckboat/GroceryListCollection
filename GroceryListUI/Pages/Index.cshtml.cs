using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata.Ecma335;


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

            public string SearchaBox { get; set; } = string.Empty;

            List<Product>? ProductSearchList { get; set; }



        }

        public class UserList
        {
            public int ListID { get; set; }

            public int productId { get; set; }

            public List<Product> products { get; set; }

        }

        [BindProperty]
        public string SearchBox { get; set; } = String.Empty;


        [BindProperty]
        public List<Product> ProductListMain { get; set; } = new List<Product>();



        [BindProperty]
        public ProductSearch ProductsListMain { get; set; } = new ProductSearch();

        [BindProperty]

        public List<UserList> UseList { get; set; } = new List<UserList>();




        public void OnGet()
        {
            // step 1
            GetDatabase();
            GetUserList();

        }

        public IActionResult GetDatabase()
        {
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
                        ProductListMain.Add(product);

                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return Page();
                }
            }
        }

        public IActionResult GetUserList()
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                // step 2
                string sql = "SELECT * FROM List WHERE ListID = 1";
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

                        UserList uList = new UserList();
                        Product product = new Product();


                        //uList.ListID = int.Parse(reader["1"].ToString());

                        //uList.products.Add( );   
                        //uList.products.   ImageURL = reader["ImageURL"].ToString();


                        //product.Price = decimal.Parse(reader["Price"].ToString());
                        //product.Ingredient = reader["Ingredient"].ToString();
                        //product.Quantity = int.Parse(reader["Quantity"].ToString());
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


        public void OnPost() // should add product to users list
        {
            Search();

            AddToList();


        }

        public void Search() {

            string sql = "SELECT * FROM Product WHERE ProductName LIKE @productName Order by ProductName";

            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {

                //step 3
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@productName", "%%%%%%%" + SearchBox + "%%%%%%");
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
                        //product.SearchBox = reader["SearchBox"].ToString();
                        ProductListMain.Add(product);


                    }
                }

            }
        }

        public IActionResult AddToList()
        {

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
                        ProductListMain.Add(product);

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

}
