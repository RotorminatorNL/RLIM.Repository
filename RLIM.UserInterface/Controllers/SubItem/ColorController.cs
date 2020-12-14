using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI;
using RLIM.UserInterface.Models;

namespace RLIM.UserInterface.Controllers
{
    public class ColorController : Controller
    {
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
                IAdmin msg =  new ColorCollection().Create(model.Name, model.Hex);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    TempData["ColorName"] = model.Name;
                    TempData["ColorHex"] = model.Hex;
                    return RedirectToAction("Create", "Color");
                }
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Update(int ID)
        {
            if (ID > 0)
            {
                return View(GetColor(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new ColorCollection().Get(model.ID).Update(model.Name, model.Hex);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Update", "Color", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Delete(int ID)
        {
            if (ID > 0)
            {
                return View(GetColor(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new ColorCollection().Delete(model.ID);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Delete", "Color", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "SubItem");
        }
    }
}
