using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace GroceryListUI.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]

        public Credential LoginInfo { get; set; }

        public void OnGet()
        {
        }

        public class Credential
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // verify user
                if (LoginInfo.Email == "cats" && LoginInfo.Password == "cats")
                {
                    // create security context

                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.Email, LoginInfo.Email),
                        new Claim(ClaimTypes.Name, "Bob"),
                        new Claim("Username", "Admin")
                    };


                    var identity = new ClaimsIdentity(claims, "GroceryCookie");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("GroceryCookie",principal);

                    return RedirectToPage("/Index");



                }

                return Page();
            }

            return Page();


        }


      

    }
}
