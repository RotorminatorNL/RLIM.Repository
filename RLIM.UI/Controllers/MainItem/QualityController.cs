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

        [Route("/Qualities")]
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
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Get(model.ID).Update(model.Name, model.Rank);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetQuality(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                new QualityCollection().Delete(model.ID);
            }

            return RedirectToAction("Index");
        }
    }
}
