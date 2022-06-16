using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.DTOs;
using Razzi.Models;
using Razzi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Razzi.Extensions;
using Newtonsoft.Json;

namespace Razzi.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private List<Product> _products = new List<Product>();
        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? genderId, int? categoryId)
        {
            
            IQueryable<Product> productQuery = _context.Products.AsNoTracking().AsQueryable();
            if (genderId.HasValue || categoryId.HasValue)
            {
                productQuery  = productQuery.Where(m => m.GenderId == genderId || m.CategoryId == categoryId);
            }
            
            _products.AddRange(await productQuery.AsNoTracking().ToListAsync());
            List<Gender> genders = await _context.Genders.AsNoTracking().ToListAsync();
            List<Size> sizes = await _context.Sizes.AsNoTracking().ToListAsync();
            List<Category> categories = await _context.Categories.AsNoTracking().ToListAsync();
            List<Price> prices = await _context.Prices.AsNoTracking().ToListAsync();

            ViewBag.categoryId = categoryId;

            
            ShopVM shopVM = new ShopVM()
            {
                Products = _products.Take(4).ToList(),
                Genders = genders,
                Sizes = sizes,
                Categories = categories,
                Prices = prices
            };
            
            HttpContext.Session.Set("products", _products);
            ViewBag.ProductCount = _products.Count;
            return View(shopVM);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            Product[] products = await _context.Products
                .Where(p => p.Name.Contains(searchString) || p.Category.Name.Contains(searchString))
                .AsNoTracking()
                .ToArrayAsync();
            return PartialView("_ProductsPartialView", products);
        }

        [HttpPost]
        public async Task<IActionResult> GetProducts([FromBody] FilterDto filterDto)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            products.Clear();

            if (filterDto.genders.Length < 1 && filterDto.categories.Length < 1 && filterDto.sizes.Length < 1 && filterDto.prices.Length < 1)
            {
                products.AddRange( await _context.Products.ToListAsync());
            }
            else
            {
                var test = await _context.Products
                    .Include(p => p.ProductSizes)
                    .Where(p =>
                    (filterDto.genders.Length == 0 || filterDto.genders.Contains(p.GenderId)) &&
                    (filterDto.prices.Length == 0 || filterDto.prices.Contains(p.PriceId)) &&
                    (filterDto.categories.Length == 0 || filterDto.categories.Contains(p.CategoryId)) &&
                    (filterDto.sizes.Length == 0 || p.ProductSizes.Any(ps => filterDto.sizes.Contains(ps.SizeId))))
                    .ToListAsync();
                products.AddRange(test);
            }
            HttpContext.Session.Set("products", products);
            
            return PartialView("_ProductsPartialView", products.Take(4).ToList());
        }


        public async Task<IActionResult> LoadMore(int skip, int take)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");

            return PartialView("_ProductsPartialView", products.Skip(skip).Take(take).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBasket(int id, int count, int sizeId)
        {
            Product dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct == null)
            {
                return BadRequest();
            }

            await UpdateBasket(dbProduct.Id, count);

            return RedirectToAction("Index", "Basket");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveBasket(int id)
        {
            List<BasketVM> basket = GetBasket();
            if (basket.Count > 0)
            {
                basket.Remove(basket.FirstOrDefault(m => m.Id == id));
                Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            }

            if(basket.Count == 0)
            {
                Response.Cookies.Delete("basket");
            }

            return RedirectToAction("Index", "Basket");
        }

        private Task UpdateBasket(int productId, int count)
        {
            List<BasketVM> basket = GetBasket();
            BasketVM existProduct = basket.FirstOrDefault(m => m.Id == productId);

            if (existProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = productId,
                    Count = count
                });
            }
            else
            {
                existProduct.Count+=count;
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return Task.CompletedTask;
        }

        private List<BasketVM> GetBasket()
        {
            if (Request.Cookies.ContainsKey("basket"))
            {
                return JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }

            return new List<BasketVM>();
        }
    }
}
