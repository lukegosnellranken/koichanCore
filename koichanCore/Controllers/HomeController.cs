using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using koichanCore.Models;

namespace koichanCore.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult WebDev()
        {
            return View();
        }

        public ActionResult Software()
        {
            return View();
        }

        public ActionResult Hardware()
        {
            return View();
        }

        public ActionResult TechCulture()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }

        public ActionResult Register()
        {
            return View("~/Areas/Identity/Pages/Account/Register.cshtml");
        }
    }
}
