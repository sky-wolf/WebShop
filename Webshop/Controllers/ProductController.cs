using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Implementation;
using WebShop.Data.Models;
using WebShop.ViewModels.Product;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public List<ProductList>? Get()
        {
            var plist = _productRepository.GetList();


            List<ProductList> list = new();

            foreach (var item in plist)
            {
                list.Add(new ProductList {
                    Id= item.Id,
                    Name= item.Name,
                    Category= item.Category,
                    Quantity= item.Quantity,
                    Description= item.Description,
                });
            }

            return list;

        }

        [HttpGet("{id}")]
        public ProductList Get(int id)
        {
            var plist = _productRepository.GetById(id);

            if(plist != null)
            {
                ProductList product = new ProductList
                {
                    Id = plist.Id,
                    Name = plist.Name,
                    Category = plist.Category,
                    Quantity = plist.Quantity,
                    Description = plist.Description,

                };

                return product;
            }


            return new ProductList();
        }

    }
}
