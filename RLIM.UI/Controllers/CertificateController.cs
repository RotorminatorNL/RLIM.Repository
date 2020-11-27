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
        [Route("[controller]/Update")]
        public IActionResult Update(int id)
        {
            if (id >= 0)
            {
                Certificate certificate = new CertificateCollection().Get(id);

                CertificateModel certificateModel = new CertificateModel
                {
                    Id = certificate.Id,
                    Name = certificate.Name,
                    Tier = certificate.Tier
                };

                return View(certificateModel);
            }

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        [Route("[controller]/Updating")]
        public IActionResult Update(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                new CertificateCollection().Get(model.Id).Update(model.Name, model.Tier);
            }

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        [Route("[controller]/Delete")]
        public IActionResult Delete(int id)
        {
            if (id >= 0)
            {
                Certificate certificate = new CertificateCollection().Get(id);

                CertificateModel certificateModel = new CertificateModel
                {
                    Id = certificate.Id,
                    Name = certificate.Name,
                    Tier = certificate.Tier
                };

                return View(certificateModel);
            }

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        [Route("[controller]/Deleting")]
        public IActionResult Delete(CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                new CertificateCollection().Delete(model.Id);
            }

            return RedirectToAction("GetAll");
        }
    }
}
