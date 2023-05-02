using WebShop.Data.Models;

namespace WebShop.Data.Implementation
{
    public interface IProductRepository
    {
        List<Product> GetList();
        Product GetById(int id);
        Task Save(Product product);
        Task Delete(int id);
    }
}
