using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;

namespace RLIM.UI.Controllers
{
    public class ColorController : Controller
    {
        public IActionResult Index()
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

            return View(colors);
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
        [Route("[controller]/Update")]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                Color color = new ColorCollection().Get(id);

                ColorModel colorModel = new ColorModel
                {
                    ID = color.ID,
                    Name = color.Name,
                    Hex = color.Hex
                };

                return View(colorModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/Updating")]
        public IActionResult Update(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                new ColorCollection().Get(model.ID).Update(model.Name, model.Hex);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/Delete")]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                Color color = new ColorCollection().Get(id);

                ColorModel ColorModel = new ColorModel
                {
                    ID = color.ID,
                    Name = color.Name,
                    Hex = color.Hex
                };

                return View(ColorModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/Deleting")]
        public IActionResult Delete(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                new ColorCollection().Delete(model.ID);
            }

            return RedirectToAction("Index");
        }
    }
}
