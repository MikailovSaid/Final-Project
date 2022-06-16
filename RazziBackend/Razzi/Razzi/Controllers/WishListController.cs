using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Razzi.Data;
using Razzi.Models;
using Razzi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Controllers
{
    public class WishListController : Controller
    {
        private readonly AppDbContext _context;
        public WishListController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (Request.Cookies["wishlist"] == null) return View();
            List<WishListVM> wishes = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishlist"]);
            List<WishListDetailVM> wishListDetailItems = new List<WishListDetailVM>();

            foreach (WishListVM item in wishes)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(m => m.Id == item.Id);
                WishListDetailVM wishListDetail = new WishListDetailVM
                {
                    Id = item.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Price = product.RealPrice,
                    StockStatus = product.StockStatus
                };
                wishListDetailItems.Add(wishListDetail);
            }
            return View(wishListDetailItems);
        }
    }
}
