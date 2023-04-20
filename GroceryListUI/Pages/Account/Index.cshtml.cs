using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using GroceryListUI.Pages.Models;

namespace GroceryListUI.Pages.Account
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; } = new User();
        //public UserCreds User { get; set; } = new UserCreds();

        public class UserCreds
        {

            public string FirstName { get; set; }
            public string LastName { get; set; }
            //[Required]
            public string Email { get; set; }
            //[Required]
            public string Password { get; set; }


        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

                if (ModelState.IsValid)
            {
                // step 1
                using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
                {

                    // step 2
                    string sql = "INSERT INTO [User]([First Name],[Last Name],Email,PasswordHash)" +
                        "VALUES(@firstName, @lastName, @email, @password)";
                    //step 3
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@firstName", NewUser.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", NewUser.LastName);
                    cmd.Parameters.AddWithValue("@email", NewUser.Email);
                    cmd.Parameters.AddWithValue("@password", NewUser.Password);
                   // cmd.Parameters.AddWithValue("@price", NewProduct.Price);
                   // cmd.Parameters.AddWithValue("@ingredient", NewProduct.Ingredient);
                   // cmd.Parameters.AddWithValue("@quantity", NewProduct.Quantity);

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

}//endedf
