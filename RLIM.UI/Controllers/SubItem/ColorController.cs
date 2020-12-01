using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;

namespace RLIM.UI.Controllers
{
    public class ColorController : Controller
    {
        private List<ColorModel> GetColors()
        {
            List<ColorModel> colors = new List<ColorModel>();

            foreach (Color color in new ColorCollection().GetAll())
            {
                colors.Add(new ColorModel
                {
                    ID = color.ID,
                    Name = color.Name,
                    Hex = color.Hex
                });
            }

            return colors;
        }

        private ColorModel GetColor(int id)
        {
            Color color = new ColorCollection().Get(id);

            return new ColorModel
            {
                ID = color.ID,
                Name = color.Name,
                Hex = color.Hex
            };
        }

        public IActionResult Index()
        {
            return View(GetColors());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                new ColorCollection().Create(model.Name, model.Hex);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetColor(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateColor(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                new ColorCollection().Get(model.ID).Update(model.Name, model.Hex);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetColor(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteColor(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                new ColorCollection().Delete(model.ID);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
