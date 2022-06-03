using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.Models;
using Razzi.Utilities.File;
using Razzi.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class IntroHomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public IntroHomeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IntroHome introHome = await _context.IntroHomes.FirstOrDefaultAsync();
            return View(introHome);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var introHome = await GetIntroById(id);
            if (introHome is null) return NotFound();
            return View(introHome);
        }

        public async Task<IActionResult> Edit(int id)
        {
            IntroHome introHome = await GetIntroById(id);

            if (introHome == null) return NotFound();

            return View(introHome);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IntroHome introHome)
        {
            var dbIntroHome = await GetIntroById(id);
            if (dbIntroHome == null) return NotFound();

            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(dbIntroHome);

            if (!introHome.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Image type is wrong");
                return View(dbIntroHome);
            }

            if (!introHome.Photo.CheckFileSize(1800))
            {
                ModelState.AddModelError("Photo", "Image size is wrong");
                return View(dbIntroHome);
            }

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/introhome", dbIntroHome.Image);

            Helper.DeleteFile(path);


            string fileName = Guid.NewGuid().ToString() + "_" + introHome.Photo.FileName;

            string newPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/introhome", fileName);

            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await introHome.Photo.CopyToAsync(stream);
            }

            dbIntroHome.Image = fileName;
            dbIntroHome.Header = introHome.Header;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<IntroHome> GetIntroById(int id)
        {
            return await _context.IntroHomes.FindAsync(id);
        }
    }
}
