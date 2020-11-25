using Microsoft.AspNetCore.Mvc;

namespace RLIM.UI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
