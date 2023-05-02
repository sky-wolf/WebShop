using WebShop.Data;
using WebShop.Data.Implementation;
using WebShop.Data.Models;

namespace WebShop.Service
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var cat = _context.Categorys.FirstOrDefault(x => x.Id == id);
            if (cat != null)
            {
                _context.Categorys.Remove(cat);
            }
            await _context.SaveChangesAsync();
        }

        public Category GetById(int id)
        {
            var cat = _context.Categorys.FirstOrDefault(c => c.Id == id);
            if(cat !=null)
            {
                return cat;
            }
            return null;
        }

        public List<Category> GetList()
        {
            return _context.Categorys.ToList();
        }

        public async Task Save(string name, string Description, int? id)
        {
            Category cat;

            if (id != null)
            {
                cat = _context.Categorys.FirstOrDefault(cat=> cat.Id == id);    

                cat.Name = name;
                cat.Description = Description;
                cat.ModifiedAt = DateTime.Now;
                _context.Categorys.Update(cat);
                await _context.SaveChangesAsync();
            }
            else
            {
                cat = new Category();

                cat.Name = name;
                cat.Description = Description;
                cat.CreateAt = DateTime.Now;
                cat.ModifiedAt = DateTime.Now;
                _context.Categorys.Add(cat);
                await _context.SaveChangesAsync();
            }
        }

    }
}
