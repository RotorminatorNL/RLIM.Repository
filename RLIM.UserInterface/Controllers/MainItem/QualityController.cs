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

        private IActionResult MessageHandler(IAdmin msg, QualityModel model, string action)
        {
            TempData["MessageTitle"] = msg.Title;
            TempData["MessageText"] = msg.Text;

            if (msg.Status == "Error")
            {
                if (action == "Create")
                {
                    TempData["QualityName"] = model.Name;
                    TempData["QualityRank"] = model.Rank;
                    return RedirectToAction("Create", "Quality");
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
        public IActionResult Create(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new QualityCollection().Create(model.Name, model.Rank);
                return MessageHandler(msg, model, "Create");
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new QualityCollection().Get(model.ID).Update(model.Name, model.Rank);
                return MessageHandler(msg, model, "Update");
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Attributes", "MainItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new QualityCollection().Delete(model.ID);
                return MessageHandler(msg, model, "Delete");
            }

            return RedirectToAction("Attributes", "MainItem");
        }
    }
}
