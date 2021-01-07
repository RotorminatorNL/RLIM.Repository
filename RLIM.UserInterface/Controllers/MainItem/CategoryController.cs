using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI.Admin;
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
                Name = category.Name,
                PreviousName = category.Name
            };
        }

        private IActionResult MessageHandler(IMessageToAdmin msg, CategoryModel model, string action)
        {
            TempData["MessageTitle"] = msg.Title;
            TempData["MessageText"] = msg.Text;

            if (msg.Status == "Error")
            {
                if (action == "Create")
                {
                    TempData["CategoryName"] = model.Name;
                    return RedirectToAction("Create", "Category");
                }
                else
                {
                    return RedirectToRoute("Controller_ID_Action", new { model.ID });
                }
            }
                
            return RedirectToAction("Attributes", "MainItem");
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
                IMessageToAdmin msg = new CategoryCollection().Create(model.Name);
                return MessageHandler(msg, model, "Create");
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new CategoryCollection().Get(model.ID);
                category.SetName(model.Name);

                return MessageHandler(category.Update(), model, "Update");
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetCategory(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                IMessageToAdmin msg = new CategoryCollection().Delete(model.ID);
                return MessageHandler(msg, model, "Delete");
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
