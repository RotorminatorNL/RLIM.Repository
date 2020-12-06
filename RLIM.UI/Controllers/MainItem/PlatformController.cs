using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLIM.UI.Controllers
{
    public class PlatformController : Controller
    {
        private List<PlatformModel> GetPlatforms()
        {
            List<PlatformModel> platforms = new List<PlatformModel>();

            foreach (Platform platform in new PlatformCollection().GetAll())
            {
                platforms.Add(new PlatformModel
                {
                    ID = platform.ID,
                    Name = platform.Name
                });
            }

            return platforms;
        }

        private PlatformModel GetPlatform(int id)
        {
            Platform platform = new PlatformCollection().Get(id);

            return new PlatformModel
            {
                ID = platform.ID,
                Name = platform.Name
            };
        }

        public IActionResult Index()
        {
            return View(GetPlatforms());
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetPlatform(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                new PlatformCollection().Get(model.ID).Update(model.Name);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetPlatform(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PlatformModel model)
        {
            if (ModelState.IsValid)
            {
                new PlatformCollection().Delete(model.ID);
            }

            return RedirectToAction("Index");
        }
    }
}
