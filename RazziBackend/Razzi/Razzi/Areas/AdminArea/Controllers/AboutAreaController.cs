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
    public class AboutAreaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutAreaController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            AboutArea aboutArea = await _context.AboutAreas.FirstOrDefaultAsync();
            return View(aboutArea);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var about = await GetAboutAreaById(id);
            if (about is null) return NotFound();
            return View(about);
        }

        public async Task<IActionResult> Edit(int id)
        {
            AboutArea about = await GetAboutAreaById(id);

            if (about == null) return NotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AboutArea about)
        {
            var dbAbout = await GetAboutAreaById(id);
            if (dbAbout == null) return NotFound();

            if (ModelState.ValidationState == ModelValidationState.Invalid) return View(dbAbout);

            if (!about.BackPhoto.CheckFileType("image/") || !about.FrontPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError("BackPhoto", "Image type is wrong");
                return View(dbAbout);
            }

            if (!about.BackPhoto.CheckFileSize(1800) || !about.FrontPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError("BackPhoto", "Image size is wrong");
                return View(dbAbout);
            }

            string backPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/aboutarea", dbAbout.BackImg);

            Helper.DeleteFile(backPath);

            string frontPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/aboutarea", dbAbout.FrontImg);

            Helper.DeleteFile(frontPath);

            string backFileName = Guid.NewGuid().ToString() + "_" + about.BackPhoto.FileName;
            string frontFileName = Guid.NewGuid().ToString() + "_" + about.BackPhoto.FileName;

            string newBackPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/aboutarea", backFileName);
            string newFrontPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/aboutarea", frontFileName);

            using (FileStream stream = new FileStream(newBackPath, FileMode.Create))
            {
                await about.BackPhoto.CopyToAsync(stream);
            }

            using (FileStream stream = new FileStream(newFrontPath, FileMode.Create))
            {
                await about.FrontPhoto.CopyToAsync(stream);
            }

            dbAbout.BackImg = backFileName;
            dbAbout.FrontImg = frontFileName;
            dbAbout.Header = about.Header;
            dbAbout.ShortDesc = about.ShortDesc;
            dbAbout.LongDesc = about.LongDesc;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<AboutArea> GetAboutAreaById(int id)
        {
            return await _context.AboutAreas.FindAsync(id);
        }
    }
}
