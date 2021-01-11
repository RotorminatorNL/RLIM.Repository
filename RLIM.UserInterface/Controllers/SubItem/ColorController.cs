using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI.Admin;
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

        private IActionResult MessageHandler(IMessageToAdmin msg, ColorModel model, string action)
        {
            TempData["MessageTitle"] = msg.Title;
            TempData["MessageText"] = msg.Text;

            if (msg.Status == "Error")
            {
                if (action == "Create")
                {
                    TempData["ColorName"] = model.Name;
                    TempData["ColorHex"] = model.Hex;
                    return RedirectToAction("Create", "Color");
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
        public IActionResult Create(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                IMessageToAdmin msg =  new ColorCollection().Create(model.Name, model.Hex);
                return MessageHandler(msg, model, "Create");
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet]
        public IActionResult Update(int ID)
        {
            if (ID > 0)
            {
                return View(GetColor(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                Color color = new ColorCollection().Get(model.ID);
                color.SetName(model.Name);
                color.SetHex(model.Hex);

                return MessageHandler(color.Update(), model, "Update");
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            if (ID > 0)
            {
                return View(GetColor(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ColorModel model)
        {
            if (ModelState.IsValid)
            {
                IMessageToAdmin msg = new ColorCollection().Delete(model.ID);
                return MessageHandler(msg, model, "Delete");
            }

            return RedirectToAction("Attributes", "SubItem");
        }
    }
}
