using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI;
using RLIM.UserInterface.Models;
using System.Collections.Generic;

namespace RLIM.UserInterface.Controllers
{
    public class CertificateController : Controller
    {
        private CertificateModel GetCertificate(int id)
        {
            Certificate certificate = new CertificateCollection().Get(id);

            return new CertificateModel
            {
                ID = certificate.ID,
                Name = certificate.Name,
                PreviousName = certificate.Name,
                Tier = certificate.Tier,
                PreviousTier = certificate.Tier
            };
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new CertificateCollection().Create(model.Name, model.Tier);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    TempData["CertificateName"] = model.Name;
                    TempData["CertificateTier"] = model.Tier;

                    return RedirectToAction("Create", "Certificate");
                }
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Update(int ID)
        {
            if (ID > 0)
            {
                return View(GetCertificate(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("/[controller]/{ID}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new CertificateCollection().Get(model.ID).Update(model.Name, model.Tier);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Update", "Certificate", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("/[controller]/{ID}/[action]")]
        public IActionResult Delete(int ID)
        {
            if (ID > 0)
            {
                return View(GetCertificate(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("/[controller]/{id}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new CertificateCollection().Delete(model.ID);
                TempData["MessageTitle"] = msg.Title;
                TempData["MessageText"] = msg.Text;

                if (msg.Status == "Error")
                {
                    return RedirectToAction("Delete", "Certificate", new { model.ID });
                }
            }

            return RedirectToAction("Attributes", "SubItem");
        }
    }
}
