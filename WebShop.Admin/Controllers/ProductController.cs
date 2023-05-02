using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Admin.ViewModels.Category;
using WebShop.Admin.ViewModels.Product;
using WebShop.Data.Implementation;
using WebShop.Data.Models;

namespace WebShop.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var pro = _productRepository.GetList();
            List<ProductList> list = new List<ProductList>();

            foreach (var item in pro)
            {
                list.Add(new ProductList { Id = item.Id, Name = item.Name, Description = item.Description, Category = item.Category.Name, Quantity = item.Quantity });
            }
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var pro = _productRepository.GetById(id);
            ProductList list = new ProductList { Id = pro.Id, Name = pro.Name, Description = pro.Description, Category = pro.Category.Name, Quantity = pro.Quantity };

            return View(list);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(_categoryRepository.GetList(), "Id", "Name"); ;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductList product, int cat)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                try
                {
                    Product pro = new Product();
                    var date = DateTime.Now;
                    pro.Name = product.Name;
                    pro.Description = product.Description;
                    pro.Quantity = product.Quantity;
                    pro.Category = _categoryRepository.GetById(cat);
                    pro.CreateAt = date;
                    pro.ModifiedAt = date;

                    _productRepository.Save(pro);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                }
            }
            ViewBag.Category = new SelectList(_categoryRepository.GetList(), "Id", "Name");

            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var pro = _productRepository.GetById(id);
            ViewBag.Category = new SelectList(_categoryRepository.GetList(), "Id", "Name", pro.Category.Id);
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductList product)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                var pro = _productRepository.GetById(product.Id);

                if(pro != null)
                {
                    var cat = _categoryRepository.GetById(id);

                    if(pro.Category.Id != cat.Id)
                    {
                        pro.Category = cat;
                    }
                    _productRepository.Save(pro);
                }
            }
            ViewBag.Category = new SelectList(_categoryRepository.GetList(), "Id", "Name");

            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
