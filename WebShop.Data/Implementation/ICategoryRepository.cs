using WebShop.Data.Models;

namespace WebShop.Data.Implementation
{
    public interface ICategoryRepository
    {
        List<Category> GetList();
        Category GetById(int id);
        Task Save (string name, string Description, int? id);
        Task Delete(int id);
    }
}
