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
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    TempData["PlatformName"] = model.Name;
                    return RedirectToAction("Create", "Platform");
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Update(int ID)
        {
            if (ID >= 0)
            {
                return View(GetPlatform(ID));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new PlatformCollection().Get(model.ID).Update(model.Name);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Update", "Platform", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Delete(int ID)
        {
            if (ID >= 0)
            {
                return View(GetPlatform(ID));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new PlatformCollection().Delete(model.ID);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Delete", "Platform", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
