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
        public async Task<IActionResult> Index(int? genderId, int? categoryId)
        {
            ViewBag.ProductCount = _context.Products.Count();
            var newTake = _context.Products.Count();
            List<Product> products = null;
            if (genderId==null && categoryId==null)
            {
                products = await _context.Products.Take(4).ToListAsync();
            }
            else
            {
                products = await _context.Products.Take(4).Where(m=>m.GenderId==genderId || m.CategoryId==categoryId).ToListAsync();
            }
            List<Gender> genders = await _context.Genders.ToListAsync();
            List<Size> sizes = await _context.Sizes.ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();

            

            ShopVM shopVM = new ShopVM()
            {
                Products = products,
                Genders = genders,
                Sizes = sizes,
                Categories = categories,
            };
            return View(shopVM);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts(int[] genderId,int[] categoryId, int? sizeId, int take = 4, int page = 1)
        {
           
            List<Product> products = new List<Product>();
            if (genderId == null && categoryId == null && sizeId == null)
            {
                products = await _context.Products.ToListAsync();
            }
            else
            {
                foreach (var item in genderId)
                {
                  List<Product>  productsGender = await _context.Products
                        .Where(m => m.GenderId == item)
                        .ToListAsync();
                    products.AddRange(productsGender);
                }
                foreach (var item in categoryId)
                {
                    List<Product> productsCategory = await _context.Products
                        .Where(m => m.CategoryId == item
                        )
                        .ToListAsync();
                    products.AddRange(productsCategory);
                }

            }
            return PartialView("_ProductsPartialView", products);
        }


        public async Task<IActionResult> LoadMore(int skip)
        {
            List<Product> products = await _context.Products.Skip(skip).Take(4).ToListAsync();
            return PartialView("_ProductsPartialView", products);
        }
    }
}
