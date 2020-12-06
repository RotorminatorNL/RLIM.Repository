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

        [HttpGet("/{mainItemName}/{mainItemID}/Sub-Items")]
        public IActionResult Index(int mainItemID)
        {
            if (mainItemID != 0)
            {
                return View(GetSubItems(mainItemID));
            }

            return RedirectToAction("Index", "MainItem");
        }

        [HttpGet("/{mainItemName}/{mainItemID}/Sub-Item/Create")]
        public IActionResult Create(int mainItemID, string mainItemName)
        {
            if (mainItemID != 0 && mainItemName != "")
            {
                ViewData["Certificates"] = GetCertificates();
                ViewData["Colors"] = GetColors();
                ViewData["MainItemID"] = mainItemID;
                ViewData["MainItemName"] = mainItemName;

                return View(new SubItemModel
                {
                    MainItemID = mainItemID,
                    MainItemDisplay = mainItemName
                });
            }

            return RedirectToAction("Index", "MainItem");
        }

        [HttpPost("/Sub-Item/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubItemModel model)
        {
            if (model.ID == 0 && model.MainItemID > 0 && model.CertificateID >= 0 && model.ColorID >= 0)
            {
                new SubItemCollection().Create(model.MainItemID, model.CertificateID, model.ColorID);
                return RedirectToRoute("SubItems", new { mainItemName = model.MainItemDisplay, mainItemID = model.MainItemID });
            }

            return RedirectToAction("Index", "MainItem");
        }

        [HttpGet("/{mainItemName}/{mainItemID}/Sub-Item/{ID}/Update")]
        public IActionResult Update(int mainItemID, string mainItemName, int ID)
        {
            if (mainItemID != 0 && mainItemName != "" && ID != 0)
            {
                return View();
            }

            return RedirectToAction("Index", "MainItem");
        }

        [HttpGet("/{mainItemName}/{mainItemID}/Sub-Item/{ID}/Delete")]
        public IActionResult Delete(int mainItemID, string mainItemName, int ID)
        {
            if (mainItemID != 0 && mainItemName != "" && ID != 0)
            {
                ViewData["MainItemID"] = mainItemID;
                ViewData["MainItemName"] = mainItemName;
                return View(GetSubItem(ID));
            }

            return RedirectToAction("Index", "MainItem");
        }

        [HttpPost("/Sub-Item/Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SubItemModel model)
        {
            if (ModelState.IsValid)
            {
                new SubItemCollection().Delete(model.ID);
                return RedirectToRoute("SubItems", new { mainItemName = model.MainItemDisplay, mainItemID = model.MainItemID });
            }

            return RedirectToAction("Index", "MainItem");
        }
    }
}
