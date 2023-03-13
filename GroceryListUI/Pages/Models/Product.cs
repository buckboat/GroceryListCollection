namespace GroceryListUI.Pages.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        
        public string ImageURL { get; set; } = string.Empty;

        public string NutritoinLabel { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Ingredients { get; set; } = string.Empty;

        public int Quantity { get; set; }

    }
}
