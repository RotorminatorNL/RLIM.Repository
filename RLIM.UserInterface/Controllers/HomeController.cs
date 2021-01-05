using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RLIM.UserInterface.Models;
using System.Diagnostics;

namespace RLIM.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserLogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogIn(LogIn model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Show", "User", new { categoryName = "All" });
            }

            return View();
        }

        public IActionResult AdminLogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogIn(LogIn model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Append("test", model.Username);
                return RedirectToAction("Index", "MainItem");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
