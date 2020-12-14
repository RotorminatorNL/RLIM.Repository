using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI;
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
                IAdmin msg = new QualityCollection().Create(model.Name, model.Rank);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    TempData["QualityName"] = model.Name;
                    TempData["QualityRank"] = model.Rank;
                    return RedirectToAction("Create", "Quality");
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Update(int ID)
        {
            if (ID > 0)
            {
                return View(GetQuality(ID));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new QualityCollection().Get(model.ID).Update(model.Name, model.Rank);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Update", "Quality", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Delete(int ID)
        {
            if (ID > 0)
            {
                return View(GetQuality(ID));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new QualityCollection().Delete(model.ID);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Delete", "Quality", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
