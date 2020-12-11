using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UserInterface.Models;
using System.Collections.Generic;

namespace RLIM.UserInterface.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryModel GetCategory(int id)
        {
            Category category = new CategoryCollection().Get(id);

            return new CategoryModel
            {
                ID = category.ID,
                Name = category.Name
            };
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
                MessageToUI msg = new CategoryCollection().Create(model.Name);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Create", "Category");
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Get(model.ID).Update(model.Name);
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new CategoryCollection().Delete(model.ID);
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
