using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.Models;
using Razzi.Utilities.Pagination;
using Razzi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? genderId, int take = 4, int page = 1)
        {
            var newTake = _context.Products.Count();
            List<Product> products = await _context.Products.ToListAsync();
            List<Gender> genders = await _context.Genders.ToListAsync();
            List<Size> sizes = await _context.Sizes.ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();

            int count = GetPageCount(products, take);
            products = products.Skip((page - 1) * take).Take(take).ToList();
            Pagination<Product> paginatedProduct = new Pagination<Product>(products, page, count);

            

            ShopVM shopVM = new ShopVM()
            {
                Products = products,
                Genders = genders,
                Sizes = sizes,
                PaginatedProducts = paginatedProduct,
                Categories = categories,
            };
            return View(shopVM);
        }
        private int GetPageCount(List<Product> products, int take)
        {
            var productCount = products.Count();
            return (int)Math.Ceiling((decimal)productCount / take);
        }
        public class InputFiltersDto
        {
            public GenderEnum Gender { get; set; }
        }
        public enum GenderEnum
        {
            Men = 1,
            Women = 2
        }
    }
}
