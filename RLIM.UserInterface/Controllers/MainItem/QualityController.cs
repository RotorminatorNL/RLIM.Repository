using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UserInterface.Models;
using System.Collections.Generic;

namespace RLIM.UserInterface.Controllers
{
    public class QualityController : Controller
    {
        private QualityModel GetQuality(int id)
        {
            Quality quality = new QualityCollection().Get(id);

            return new QualityModel
            {
                ID = quality.ID,
                Name = quality.Name,
                Rank = quality.Rank
            };
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Create(model.Name, model.Rank);
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Get(model.ID).Update(model.Name, model.Rank);
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Delete(model.ID);
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
