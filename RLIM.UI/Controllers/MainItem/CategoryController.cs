using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class CategoryController : Controller
    {
        private List<CategoryModel> GetCategorys()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            foreach (Category category in new CategoryCollection().GetAll())
            {
                categories.Add(new CategoryModel
                {
                    ID = category.ID,
                    Name = category.Name
                });
            }

            return categories;
        }

        private CategoryModel GetCategory(int id)
        {
            Category category = new CategoryCollection().Get(id);

            return new CategoryModel
            {
                ID = category.ID,
                Name = category.Name
            };
        }

        public IActionResult Index()
        {
            return View(GetCategorys());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Create(model.Name);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Get(model.ID).Update(model.Name);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Delete(model.ID);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
