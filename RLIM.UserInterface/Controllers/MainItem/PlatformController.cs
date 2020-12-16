using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI;
using RLIM.UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLIM.UserInterface.Controllers
{
    public class PlatformController : Controller
    {
        private PlatformModel GetPlatform(int id)
        {
            Platform platform = new PlatformCollection().Get(id);

            return new PlatformModel
            {
                ID = platform.ID,
                Name = platform.Name
            };
        }

        private IActionResult MessageHandler(IAdmin msg, PlatformModel model, string action)
        {
            TempData["MessageTitle"] = msg.Title;
            TempData["MessageText"] = msg.Text;

            if (msg.Status == "Error")
            {
                if (action == "Create")
                {
                    TempData["PlatformName"] = model.Name;
                    return RedirectToAction("Create", "Platform");
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
        public IActionResult Create(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new PlatformCollection().Create(model.Name);
                return MessageHandler(msg, model, "Create");
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetPlatform(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new PlatformCollection().Get(model.ID).Update(model.Name);
                return MessageHandler(msg, model, "Update");
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetPlatform(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new PlatformCollection().Delete(model.ID);
                return MessageHandler(msg, model, "Delete");
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
