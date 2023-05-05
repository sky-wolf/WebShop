using WebShop.Data.Models;

namespace WebShop.Data.Implementation
{
    public interface IOrderItemsRepository
    {
        List<OrderItems> GetListByOrder(int id);
        Task Insert(OrderItems orderItems, Order order);
        Task Delete(int id);
    }
}
