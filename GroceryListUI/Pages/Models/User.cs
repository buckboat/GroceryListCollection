using System.ComponentModel.DataAnnotations;

namespace GroceryListUI.Pages.Models
{

    public class User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }




    }

}
