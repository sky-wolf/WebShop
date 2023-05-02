using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebShop.Data;
using WebShop.Data.Implementation;
using WebShop.Data.Models;

namespace WebShop.Service
{
    public class ProductService : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.Include(x => x.Category ).FirstOrDefault(p => p.Id == id);
            if (product == null) return null;

            return product;
        }

        public List<Product> GetList()
        {
            List<Product> products = _context.Products.Include(x => x.Category).ToList();
            return products;
        }

        public async Task Save(Product product)
        {
            if(product.Id == 0)
            {
                _context.Products.Add(product);

            }
            else
            {
                product.ModifiedAt = DateTime.Now;
                _context.Products.Update(product);

            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var delItem = _context.Products.FirstOrDefault(x => x.Id == id);
            if(delItem != null)
            {
                _context.Products.Remove(delItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
