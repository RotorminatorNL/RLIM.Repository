using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class CertificateController : Controller
    {
        private List<CertificateModel> GetCertificates()
        {
            List<CertificateModel> certificates = new List<CertificateModel>();

            foreach (Certificate certificate in new CertificateCollection().GetAll())
            {
                certificates.Add(new CertificateModel
                {
                    ID = certificate.ID,
                    Name = certificate.Name,
                    Tier = certificate.Tier
                });
            }

            return certificates;
        }

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

        public IActionResult Index()
        {
            return View(GetCertificates());
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
                return RedirectToAction("Index");
            }
                
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                return View(GetCertificate(id));
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCertificate(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                new CertificateCollection().Get(model.ID).Update(model.Name, model.Tier);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                return View(GetCertificate(id));
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCertificate(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                new CertificateCollection().Delete(model.ID);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
