using WebShop.Data.Models;

namespace WebShop.Data.Implementation
{
    public interface IOrderRepository
    {
        List<Order> GetList();
        List<Order> GetOrdersForUser(string id);
        Order GetById(int id);
        Task<Order> Save(Order order);
        Task Delete(int id);
    }
}
