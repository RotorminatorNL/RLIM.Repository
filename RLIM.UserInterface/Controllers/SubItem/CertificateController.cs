using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
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
                Tier = certificate.Tier
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
                new CertificateCollection().Create(model.Name, model.Tier);
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                return View(GetCertificate(id));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                new CertificateCollection().Get(model.ID).Update(model.Name, model.Tier);
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpGet("/[controller]/{id}/[action]")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetCertificate(id));
            }

            return RedirectToAction("Attributes", "SubItem");
        }

        [HttpPost("/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                new CertificateCollection().Delete(model.ID);
            }

            return RedirectToAction("Attributes", "SubItem");
        }
    }
}
