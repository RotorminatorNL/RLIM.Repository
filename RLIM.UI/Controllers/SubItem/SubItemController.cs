using Microsoft.AspNetCore.Mvc;
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
                Name = certificate.Name,
                Tier = certificate.Tier,
                Display = certificate.Name == "None" ? certificate.Name : $"{certificate.Name} ({certificate.Tier})"
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
                    Name = certificate.Name,
                    Tier = certificate.Tier,
                    Display = certificate.Name == "None" ? certificate.Name : $"{certificate.Name} ({certificate.Tier})"
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
                Name = color.Name,
                Hex = color.Hex,
                Display = color.Name == "Default" ? color.Name : $"{color.Name} ({color.Hex})"
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
                    Name = color.Name,
                    Hex = color.Hex,
                    Display = color.Name == "Default" ? color.Name : $"{color.Name} ({color.Hex})"
                });
            }

            return colors;
        }

        private List<SubItemModel> GetSubItems(int mainItemID)
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            MainItem mainItem = new MainItemCollection().Get(mainItemID);

            foreach (SubItem subItem in mainItem.GetSubItems())
            {
                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    MainItemDisplay = mainItem.Name,
                    MainItemID = mainItem.ID,
                    CertificateDisplay = GetCertificate(subItem.CertificateID).Display,
                    ColorDisplay = GetColor(subItem.ColorID).Display
                });
            }

            return subItemModels;
        }

        public IActionResult Index(int id)
        {
            return View(GetSubItems(id));
        }

        public IActionResult Create()
        {
            ViewBag.Certificates = GetCertificates();
            ViewBag.Colors = GetColors();
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubItemModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}
