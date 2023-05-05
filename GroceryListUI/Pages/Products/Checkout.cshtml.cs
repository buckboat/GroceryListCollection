using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryListUI.Pages.Models;
using static GroceryListUI.Pages.IndexModel;
using Microsoft.Data.SqlClient;



namespace GroceryListUI.Pages.Products
{


    

    [Authorize]
    public class CheckoutModel : PageModel
    {

        [BindProperty]
        public List<UserList> Bob { get; set; } = new List<UserList>();

   

       
        public IActionResult OnGet()
        {


                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {
                    // step 2
                    string sql = "SELECT Product.ProductID, Product.ImageURL, Product.ProductName, Product.Price,List.ListID,ListProduct.ProductQuantity,ListProduct.Discount " +
                       "FROM ((Product INNER JOIN ListProduct ON Product.ProductID = ListProduct.ProductID)" +
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
                            uList.ProductID = int.Parse(reader["ProductID"].ToString());
                            uList.ImageURL = reader["ImageURL"].ToString();
                            uList.Price = decimal.Parse(reader["Price"].ToString());
                            uList.ProductName = reader["ProductName"].ToString();
                            uList.Quantity = int.Parse(reader["ProductQuantity"].ToString());
                            uList.Discount = decimal.Parse(reader["Discount"].ToString());
                            Bob.Add(uList);

                        }
                        return Page();
                    }
                    else
                    {
                        return Page();
                    }
                }
            

        }
        
    }
}
