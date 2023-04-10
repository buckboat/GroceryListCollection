using System.ComponentModel.DataAnnotations;

namespace GroceryListUI.Pages.Models
{
    public class Product
    {

        public string SearchBox { get; set; } = string.Empty;

        public int ProductID { get; set; }
        [Required(ErrorMessage ="This field is required!")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage ="This field is required by state law.")]
        public string ImageURL { get; set; } = string.Empty;

        public string NutrtionLabel { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage ="Talk about Me!")]
        public decimal Price { get; set; }

        public string Ingredient { get; set; } = string.Empty;

        public int Quantity { get; set; }

    }
}
