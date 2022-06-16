using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Razzi.Data;
using Razzi.Models;
using Razzi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Razzi.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (Request.Cookies["basket"] == null) return View();
            List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            List<BasketDetailVM> basketDetailItems = new List<BasketDetailVM>();

            foreach (BasketVM item in basket)
            {
                Product product = await _context.Products.Include(m => m.ProductSizes).FirstOrDefaultAsync(m => m.Id == item.Id);
                BasketDetailVM basketDetail = new BasketDetailVM 
                { 
                    Id = item.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Count = item.Count,
                    Price = product.RealPrice * item.Count,
                };
                basketDetailItems.Add(basketDetail);
            }
            return View(basketDetailItems);
        }
    }
}
