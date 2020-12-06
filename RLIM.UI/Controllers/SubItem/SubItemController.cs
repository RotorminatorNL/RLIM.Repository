using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class SubItemController : Controller
    {
        private CertificateModel GetCertificate(int id)
        {
            Certificate certificate = new CertificateCollection().Get(id);

            return new CertificateModel
            {
                ID = certificate.ID,
                Display = certificate.ID == 0 ? certificate.Name : $"{certificate.Name} ({certificate.Tier})"
            };
        }

        private List<CertificateModel> GetCertificates()
        {
            List<CertificateModel> certificates = new List<CertificateModel>();

            foreach (Certificate certificate in new CertificateCollection().GetAll())
            {
                certificates.Add(new CertificateModel
                {
                    ID = certificate.ID,
                    Display = $"{certificate.Name} ({certificate.Tier})"
                });
            }

            return certificates;
        }

        private ColorModel GetColor(int id)
        {
            Color color = new ColorCollection().Get(id);

            return new ColorModel
            {
                ID = color.ID,
                Display = color.ID == 0 ? color.Name : $"{color.Name} ({color.Hex})"
            };
        }

        private List<ColorModel> GetColors()
        {
            List<ColorModel> colors = new List<ColorModel>();

            foreach (Color color in new ColorCollection().GetAll())
            {
                colors.Add(new ColorModel
                {
                    ID = color.ID,
                    Display = $"{color.Name} ({color.Hex})"
                });
            }

            return colors;
        }

        private SubItemModel GetSubItem(int id)
        {
            SubItem subItem = new SubItemCollection().Get(id);

            CertificateModel certificate = GetCertificate(subItem.CertificateID);
            ColorModel color = GetColor(subItem.ColorID);

            return new SubItemModel 
            { 
                ID = subItem.ID,
                MainItemID = subItem.MainItemID,
                CertificateID = certificate.ID,
                CertificateDisplay = certificate.Display,
                ColorID = color.ID,
                ColorDisplay = color.Display
            };
        }

        private List<SubItemModel> GetSubItems(int id)
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            MainItem mainItem = new MainItemCollection().Get(id);

            ViewData["MainItemID"] = mainItem.ID;
            ViewData["MainItemName"] = mainItem.Name;

            foreach (SubItem subItem in mainItem.GetSubItems())
            {
                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    MainItemID = mainItem.ID,
                    CertificateDisplay = GetCertificate(subItem.CertificateID).Display,
                    ColorDisplay = GetColor(subItem.ColorID).Display
                });
            }

            return subItemModels;
        }

        public IActionResult Index(int id)
        {
            if (id == 0)
            {
                if (TempData["MainItemID"] == null)
                {
                    return RedirectToAction("Index", "MainItem");
                }

                id = (int)TempData["MainItemID"];
            }
            return View(GetSubItems(id));
        }

        public IActionResult Create()
        {
            if (TempData["MainItemID"] != null && TempData["MainItemName"] != null)
            {
                ViewData["Certificates"] = GetCertificates();
                ViewData["Colors"] = GetColors();
                ViewData["MainItemID"] = TempData["MainItemID"];
                ViewData["MainItemName"] = TempData["MainItemName"];

                return View(new SubItemModel
                {
                    MainItemID = (int)TempData["MainItemID"]
                });
            }

            return RedirectToAction("Index", "MainItem");
        }

        [HttpPost]
        public IActionResult CreateSubItem(SubItemModel model)
        {
            if (model.ID == 0 && model.MainItemID > 0 && model.CertificateID >= 0 && model.ColorID >= 0)
            {
                new SubItemCollection().Create(model.MainItemID, model.CertificateID, model.ColorID);
                TempData["MainItemID"] = model.MainItemID;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "MainItem");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0 && TempData["MainItemID"] != null && TempData["MainItemName"] != null)
            {
                ViewData["MainItemID"] = TempData["MainItemID"];
                ViewData["MainItemName"] = TempData["MainItemName"];
                return View(GetSubItem(id));
            }

            return RedirectToAction("Index", "MainItem");
        }

        public IActionResult DeleteSubItem(SubItemModel model)
        {
            if (ModelState.IsValid)
            {
                new SubItemCollection().Delete(model.ID);
                TempData["MainItemID"] = model.MainItemID;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "MainItem");
        }
    }
}
