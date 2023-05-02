using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Admin.ViewModels.Category;
using WebShop.Data.Implementation;
using WebShop.Data.Models;

namespace WebShop.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        // GET: CategoryController
        public ActionResult Index()
        {
            var cat = _categoryRepository.GetList();
            List<CategoryList> list= new List<CategoryList>();

            foreach(var item in cat)
            {
                list.Add(new CategoryList { Id = item.Id, Name = item.Name, Description = item.Description });
            }
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryList category)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var date = DateTime.Now;

                    _categoryRepository.Save(category.Name, category.Description, null);
                    return RedirectToAction(nameof(Index));

                }

                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = _categoryRepository.GetById(id);
            CategoryList list = new CategoryList { Id= cat.Id, Name = cat.Name, Description = cat.Description };

            return View(list);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryList category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var date = DateTime.Now;

                    _categoryRepository.Save(category.Name, category.Description, category.Id);
                    return RedirectToAction(nameof(Index));

                }

                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = _categoryRepository.GetById(id);
            if(cat == null)
            {
                return BadRequest();
            }

            _categoryRepository.Delete(cat.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
