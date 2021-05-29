using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using koichanCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

//namespace koichanCore.Controllers
namespace koichanCore.Models
{
    public class AccountController : Controller
    {
        private readonly AvatarsDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountController(AvatarsDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReturnAvatar()
        {
            //return View("~/Areas/Identity/Pages/Account/Manage/Avatar.cshtml");
            return View("AvatarUpdated");
        }

        public ActionResult Login()
        {
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }

        public ActionResult Register()
        {
            return View("~/Areas/Identity/Pages/Account/Register.cshtml");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SetAvatar([Bind("ImageID, ImageFile")] AvatarsModel avatarsModel)
        //public async Task<IActionResult> SetAvatar(AvatarsModel avatarsModel)
        {
            if (ModelState.IsValid)
            {
                // Save image to wwwroot/avatar
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(avatarsModel.ImageFile.FileName);
                string extension = Path.GetExtension(avatarsModel.ImageFile.FileName);
                avatarsModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/avatar/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await avatarsModel.ImageFile.CopyToAsync(fileStream);
                }

                //Insert record
                _context.Add(avatarsModel);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(ReturnAvatar));
                //return View("~/Areas/Identity/Pages/Account/Manage/Avatar.cshtml");
            }
            //return View(avatarsModel);
            //return View("~/Views/Shared/SetAvatar.cshtml");
            //return RedirectToAction(nameof(ReturnAvatar));
            return ReturnAvatar();
            //return View("Avatar");
            //return View("~/Areas/Identity/Pages/Account/Manage/Avatar.cshtml");
            //return RedirectToAction(nameof(ReturnAvatar), ViewData["Title"], ViewData["ActivePage"]);
            //return View(new AvatarsModel());
        }

    }
}
