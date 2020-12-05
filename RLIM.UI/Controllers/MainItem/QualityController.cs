using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLIM.UI.Controllers
{
    public class QualityController : Controller
    {
        private List<QualityModel> GetQualitys()
        {
            List<QualityModel> qualities = new List<QualityModel>();

            foreach (Quality quality in new QualityCollection().GetAll())
            {
                qualities.Add(new QualityModel
                {
                    ID = quality.ID,
                    Name = quality.Name,
                    Rank = quality.Rank
                });
            }

            return qualities;
        }

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

        public IActionResult Index()
        {
            return View(GetQualitys());
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
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateQuality(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Get(model.ID).Update(model.Name, model.Rank);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteQuality(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Delete(model.ID);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
