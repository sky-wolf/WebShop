namespace WebShop.ViewModels.Order
{
    public class CheckoutViewModel
    {
        public string Id { get; set; }

        public int Total { get; set; }

        public List<CheckoutProductModel> Data { get; set; }
    }
}
