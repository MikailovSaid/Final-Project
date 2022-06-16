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
    public class GenderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public GenderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Gender> genders = await _context.Genders.ToListAsync();
            return View(genders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gender gender)
        {
            Gender dbGender = await _context.Genders.FirstOrDefaultAsync();
            if (ModelState.ValidationState == ModelValidationState.Invalid) return View();


            if (dbGender.Name.ToLower().Trim() == gender.Name.ToLower().Trim())
            {
                return RedirectToAction(nameof(Index));
            }

            bool isExist = _context.Genders.Any(m => m.Name.ToLower().Trim() == gender.Name.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View();
            }

            await _context.AddAsync(gender);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Gender gender = await GetGenderById(id);

            if (gender == null) return NotFound();

            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Gender gender = await _context.Genders.Where(m => m.Id == id).FirstOrDefaultAsync();

            if (gender == null) return NotFound();

            return View(gender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gender gender)
        {
            if (!ModelState.IsValid) return View();

            if (id != gender.Id) return BadRequest();

            try
            {
                Gender dbGender = await _context.Genders.Where(m => m.Id == id).FirstOrDefaultAsync();


                if (dbGender.Name.ToLower().Trim() == gender.Name.ToLower().Trim())
                {
                    return RedirectToAction(nameof(Index));
                }

                bool isExist = _context.Genders.Any(m => m.Name.ToLower().Trim() == gender.Name.ToLower().Trim());
                if (isExist)
                {
                    ModelState.AddModelError("Name", "This gender already exists");
                    return View();
                }

                dbGender.Name = gender.Name;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }

        private async Task<Gender> GetGenderById(int id)
        {
            return await _context.Genders.FindAsync(id);
        }
    }
}
