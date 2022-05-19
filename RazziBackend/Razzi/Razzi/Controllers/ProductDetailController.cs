using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        public ProductDetailController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            Product product = await _context.Products.Where(m=>m.Id == id)
                .Include(m=>m.ProductSizes).ThenInclude(m=>m.Size)
                .Include(m=>m.Category)
                .Include(m=>m.Gender).FirstOrDefaultAsync();

            return View(product);
        }
    }
}
