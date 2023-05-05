using WebShop.Data.Models;

namespace WebShop.Admin.ViewModels.Orders
{
    public class OrderViewModel
    {
        public Order Detail { get; set; }
        public List<OrderItems> Items { get; set; }
    }
}
