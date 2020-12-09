using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
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
                new PlatformCollection().Create(model.Name);
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetPlatform(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                new PlatformCollection().Get(model.ID).Update(model.Name);
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetPlatform(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                new PlatformCollection().Delete(model.ID);
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
