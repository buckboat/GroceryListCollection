using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;


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

            public int ProductID { get; set; }

            public string ProductName { get; set; } = string.Empty;

            public string ImageURL { get; set; } = string.Empty;

            public string NutrtionLabel { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;

            public decimal Price { get; set; }

            public string Ingredient { get; set; } = string.Empty;

            public int Quantity { get; set; }

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
                string sql = "SELECT Product.ProductID, Product.ImageURL, Product.ProductName, Product.Price,List.ListID,Product.Quantity " +
                   "FROM ((Product INNER JOIN ListProduct ON Product.ProductID = ListProduct.ProductID)"+
                                  "INNER JOIN List ON List.ListID = ListProduct.ListID) WHERE List.ListId = 1 Order by Product.ProductName";

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



                        //uList.ListID = int.Parse(reader["1"].ToString());

                        uList.ImageURL = reader["ImageURL"].ToString();
                        uList.Price = decimal.Parse(reader["Price"].ToString());
                        uList.ProductName = reader["ProductName"].ToString();
                        uList.Quantity = int.Parse(reader["Quantity"].ToString());
                        UseList.Add(uList);

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
                string sql = "INSERT INTO ListProduct(ListID, ProductID) VALUES(1,@productID)";
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

                        //product.ProductName = reader["ProductName"].ToString();
                        //product.ImageURL = reader["ImageURL"].ToString();
                        //product.NutrtionLabel = reader["NutrtionLabel"].ToString();
                        //product.Description = reader["Description"].ToString();
                        //product.Price = decimal.Parse(reader["Price"].ToString());
                        //product.Ingredient = reader["Ingredient"].ToString();
                        //product.Quantity = int.Parse(reader["Quantity"].ToString());
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
