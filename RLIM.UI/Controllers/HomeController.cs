using Microsoft.AspNetCore.Mvc;
using RLIM.UI.Models;
using System.Collections.Generic;
using RLIM.DataAccess;
using RLIM.BusinessLogic.Certificate;
using RLIM.BusinessLogic.Certificate.Admin;
using System.Threading.Tasks;

namespace RLIM.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _dBContext;

        public HomeController(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
