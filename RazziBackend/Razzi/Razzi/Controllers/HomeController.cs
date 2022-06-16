using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.Models;
using Razzi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IntroHome introHome = await _context.IntroHomes.FirstOrDefaultAsync();
            List<BestSellers> bestSellers = await _context.BestSellers.ToListAsync();
            Video video = await _context.Videos.FirstOrDefaultAsync();
            List<Gender> genders = await _context.Genders.Take(2).ToListAsync();
            List<Product> products = await _context.Products.Include(m => m.ProductSizes).ThenInclude(m => m.Size)
                .Include(m => m.Category)
                .Include(m => m.Gender).ToListAsync();
            List<Category> categories = await _context.Categories.Take(6).ToListAsync();

            HomeVM homeVM = new HomeVM()
            {
                IntroHome = introHome,
                BestSellers = bestSellers,
                Video = video,
                Genders = genders,
                Products = products,
                Categories = categories,
            };
            return View(homeVM);
        }
    }
}
