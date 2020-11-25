using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class CertificateController : Controller
    {
        public IActionResult GetAll()
        {
            List<CertificateModel> certificates = new List<CertificateModel>();

            foreach (Certificate certificate in new CertificateCollection().GetaAll())
            {
                certificates.Add(new CertificateModel 
                { 
                    Id = certificate.Id,
                    Name = certificate.Name,
                    Tier = certificate.Tier
                });
            }

            return View(certificates);
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
                return RedirectToAction("GetAll");
            }
                
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {

            }

            return RedirectToAction("GetAll");
        }

        public IActionResult Updating(CertificateModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {

            }

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public IActionResult Deleting(int id)
        {
            if (id >= 0)
            {

            }

            return RedirectToAction("GetAll");
        }
    }
}
