using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UserInterface.Models;
using System.Collections.Generic;

namespace RLIM.UserInterface.Controllers
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

        [Route("/Categories")]
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
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Get(model.ID).Update(model.Name);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Delete(model.ID);
            }

            return RedirectToAction("Index");
        }
    }
}
