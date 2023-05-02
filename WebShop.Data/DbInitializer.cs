using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder
                .ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>()!;

            if(!context.Categorys.Any())
            {
                context.Categorys.AddRange(Category.Select(c => c.Value));
                context.SaveChanges();
            }
            if(!context.Products.Any())
            {
                context.Products.AddRange(Products.Select(c => c.Value));
                context.SaveChanges();
            }
        }

        private static Dictionary<String, Category>? _category;
        public static Dictionary<String, Category> Category
        {

            get
            {
                if(_category == null)
                {
                    var list = new Category[]
                    {
                        new Category { Name = "Test1", Description = "test 1", CreateAt= DateTime.Now },
                        new Category { Name = "Test2", Description = "test 2", CreateAt= DateTime.Now },
                    };

                    _category = new Dictionary<string, Category>();
                    foreach (var category in list)
                    {
                        _category[category.Name] = category;
                    }
                }
                return _category;
            }
        }

        private static Dictionary<String, Product>? _products;
        public static Dictionary<String, Product> Products
        {

            get
            {
                if (_products == null)
                {
                    var list = new Product[]
                    {
                        new Product { Name = "Anna1", Description = "1", Quantity = 150, Category = Category["Test1"], CreateAt = DateTime.Now },
                        new Product { Name = "Anna2", Description = "2", Quantity = 150, Category = Category["Test2"], CreateAt = DateTime.Now },
                        new Product { Name = "Anna3", Description = "3", Quantity = 150, Category = Category["Test1"], CreateAt = DateTime.Now },
                        new Product { Name = "Anna4", Description = "4", Quantity = 150, Category = Category["Test2"], CreateAt = DateTime.Now },
                        new Product { Name = "Anna5", Description = "5", Quantity = 150, Category = Category["Test1"], CreateAt = DateTime.Now },
                    };

                    _products = new Dictionary<string, Product>();
                    foreach (var item in list)
                    {
                        _products[item.Name] = item;
                    }
                }
                return _products;
            }
        }
    }
}
