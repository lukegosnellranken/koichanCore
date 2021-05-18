using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace koichanCore.Models
{
    public class AvatarController : Controller
    {
        private readonly AvatarsDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AvatarController(AvatarsDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Avatar
        public async Task<IActionResult> Index()
        {
            return View(await _context.AspNetUserAvatars.ToListAsync());
        }

        // GET: Avatar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avatarsModel = await _context.AspNetUserAvatars
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (avatarsModel == null)
            {
                return NotFound();
            }

            return View(avatarsModel);
        }

        // GET: Avatar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avatar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageID,Title,ImageFile")] AvatarsModel avatarsModel)
        {
            if (ModelState.IsValid)
            {
                // Save image to wwwroot/avatar
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(avatarsModel.ImageFile.FileName);
                string extension = Path.GetExtension(avatarsModel.ImageFile.FileName);
                avatarsModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/avatar/", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await avatarsModel.ImageFile.CopyToAsync(fileStream);
                }
                
                //Insert record
                _context.Add(avatarsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avatarsModel);
        }

        // GET: Avatar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avatarsModel = await _context.AspNetUserAvatars.FindAsync(id);
            if (avatarsModel == null)
            {
                return NotFound();
            }
            return View(avatarsModel);
        }

        // POST: Avatar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageID,Title,ImageName")] AvatarsModel avatarsModel)
        {
            if (id != avatarsModel.ImageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avatarsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvatarsModelExists(avatarsModel.ImageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(avatarsModel);
        }

        // GET: Avatar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avatarsModel = await _context.AspNetUserAvatars
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (avatarsModel == null)
            {
                return NotFound();
            }

            return View(avatarsModel);
        }

        // POST: Avatar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avatarsModel = await _context.AspNetUserAvatars.FindAsync(id);
            _context.AspNetUserAvatars.Remove(avatarsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvatarsModelExists(int id)
        {
            return _context.AspNetUserAvatars.Any(e => e.ImageID == id);
        }
    }
}
