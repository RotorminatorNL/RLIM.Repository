using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RLIM.DataAccess;
using RLIM.UI.Models;

namespace RLIM.UI.Controllers
{
    public class CertificateController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
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
