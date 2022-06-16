using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Razzi.Data;
using Razzi.Models;
using Razzi.ViewModels;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWishList(int? id)
        {
            if (id is null) return NotFound();

            Product dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct == null) return BadRequest();

            List<WishListVM> wishes = GetWishList();

            UpdateWishList(wishes, dbProduct);

            Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishes));

            return RedirectToAction("Index", "Shop");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveWishList(int? id)
        {
            List<WishListVM> basket = GetWishList();
            if (basket.Count > 0)
            {
                basket.Remove(basket.FirstOrDefault(m => m.Id == id));
                Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(basket));
            }

            if (basket.Count == 0)
            {
                Response.Cookies.Delete("wishlist");
            }

            return RedirectToAction("Index", "WishList");
        }

        private void UpdateWishList(List<WishListVM> wishes, Product product)
        {
            var existProduct = wishes.Find(m => m.Id == product.Id);

            if (existProduct == null)
            {
                wishes.Add(new WishListVM
                {
                    Id = product.Id,
                });
            }
            else
            {
                return;
            }
        }

        private List<WishListVM> GetWishList()
        {
            List<WishListVM> wishes;
            if (Request.Cookies["wishlist"] != null)
            {
                wishes = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishlist"]);
            }
            else
            {
                wishes = new List<WishListVM>();
            }

            return wishes;
        }
    }
}
