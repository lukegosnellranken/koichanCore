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
    public class AccountController : Controller
    {
        public IActionResult Index()
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
