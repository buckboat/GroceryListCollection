using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryListUI.Pages.Account
{
    public class IndexModel : PageModel
    {
        //[BindProperty]
        public UserCreds User { get; set; } = new UserCreds();

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

        public void OnPost()
        {

            if (ModelState.IsValid)
            {

                if (User.Email == "admin@mysite.com" && User.Password == "Password")
                {
                    // creds verified

                    //create secuirty context
                }


            }

        }
    }

}//end
