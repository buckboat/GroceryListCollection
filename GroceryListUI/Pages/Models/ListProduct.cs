using System.ComponentModel.DataAnnotations;

namespace GroceryListUI.Pages.Models
{
    public class ListProduct
    {
        public int ListID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Discount { get; set; }
    }
}
