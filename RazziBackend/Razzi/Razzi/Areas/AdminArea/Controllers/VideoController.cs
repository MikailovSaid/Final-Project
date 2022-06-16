using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class VideoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public VideoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            Video video = await _context.Videos.FirstOrDefaultAsync();
            return View(video);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Video video = await GetVideoById(id);

            if (video == null) return NotFound();

            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Video video)
        {
            var dbVideo = await GetVideoById(id);
            if (dbVideo == null) return NotFound();

            if (ModelState.ValidationState == ModelValidationState.Invalid) return View(dbVideo);

            dbVideo.VideoLink = video.VideoLink;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private async Task<Video> GetVideoById(int id)
        {
            return await _context.Videos.FindAsync(id);
        }
    }
}
