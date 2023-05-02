using WebShop.Data.Models;

namespace WebShop.ViewModels.Product
{
    public class ProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
