using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI;
using RLIM.UserInterface.Models;
using System.Collections.Generic;

namespace RLIM.UserInterface.Controllers
{
    [Route("/[controller]")]
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

        private IActionResult MessageHandler(IAdmin msg, CertificateModel model, string action)
        {
            TempData["MessageTitle"] = msg.Title;
            TempData["MessageText"] = msg.Text;

            if (msg.Status == "Error")
            {
                if (action == "Create")
                {
                    TempData["CertificateName"] = model.Name;
                    TempData["CertificateTier"] = model.Tier;
                    return RedirectToAction("Create", "Certificate");
                }
                else
                {
                    return RedirectToAction(action, "Certificate", new { model.ID });
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
        public IActionResult Create(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new CertificateCollection().Create(model.Name, model.Tier);
                return MessageHandler(msg, model, "Create");
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("{id}/[action]")]
        public IActionResult Update(int ID)
        {
            if (ID > 0)
            {
                return View(GetCertificate(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("{id}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new CertificateCollection().Get(model.ID).Update(model.Name, model.Tier);
                return MessageHandler(msg, model, "Update");
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("{id}/[action]")]
        public IActionResult Delete(int ID)
        {
            if (ID > 0)
            {
                return View(GetCertificate(ID));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("{id}/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                IAdmin msg = new CertificateCollection().Delete(model.ID);
                return MessageHandler(msg, model, "Delete");
            }

            return RedirectToAction("Attributes", "SubItem");
        }
    }
}
