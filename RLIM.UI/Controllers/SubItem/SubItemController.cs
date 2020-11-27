using Microsoft.AspNetCore.Mvc;
using RLIM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLIM.UI.Controllers
{
    public class SubItemController : Controller
    {
        public IActionResult Index()
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            return View(subItemModels);
        }
    }
}
