using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Razzi.Data;
using Razzi.Models;
using Razzi.Utilities.File;
using Razzi.Utilities.Helpers;
using Razzi.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Razzi.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product = await _context.Products
                .Include(m => m.ProductSizes)
                .ThenInclude(m => m.Size)
                .Include(m => m.Category)
                .Include(m => m.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["PriceId"] = new SelectList(_context.Prices, "Id", "MinPrice");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!productVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Image type is wrong");
                return View();
            }

            if (!productVM.Photo.CheckFileSize(1800))
            {
                ModelState.AddModelError("Photo", "Image size is wrong");
                return View();
            }

            string fileName = $"{Guid.NewGuid()} {productVM.Photo.FileName}";

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await productVM.Photo.CopyToAsync(stream);
            }

            using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    Product product = new Product()
                    {
                        Image = fileName,
                        Name = productVM.Name,
                        Desc = productVM.Desc,
                        RealPrice = productVM.RealPrice,
                        Count = productVM.Count,
                        StockStatus = productVM.StockStatus,
                        TopItem = productVM.TopItem,
                        CategoryId = productVM.CategoryId,
                        GenderId = productVM.GenderId,
                        PriceId = productVM.PriceId,
                    };
                    await _context.AddAsync(product);
                    await _context.SaveChangesAsync();

                    if (productVM.ProductSizes != null)
                    {
                        foreach (int id in productVM.ProductSizes)
                        {
                            product.ProductSizes.Add(new ProductSize
                            {
                                ProductId = product.Id,
                                SizeId = id
                            });
                        }
                    }
                    

                    _context.Update(product);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
           
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["PriceId"] = new SelectList(_context.Prices, "Id", "MinPrice");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Product product = await GetProductById(id);
            if (product is null) return NotFound();
            ProductVM productVM = new ProductVM
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                RealPrice = product.RealPrice,
                StockStatus = product.StockStatus,
                Desc = product.Desc,
                Count = product.Count,
                TopItem = product.TopItem,
                GenderId = product.GenderId,
                PriceId = product.PriceId
            };

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["PriceId"] = new SelectList(_context.Prices, "Id", "MinPrice");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name");
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            Product product = await GetProductById(id);

            if (product is null)
            {
                return NotFound();

            }

            if (productVM.Photo != null)
            {
                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", product.Image);
                Helper.DeleteFile(path);


                string fileName = $"{Guid.NewGuid()} {productVM.Photo.FileName}";

                string newPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", fileName);

                await productVM.Photo.SaveFile(newPath);

                product.Image = fileName;
            }

            product.Name = productVM.Name;
            product.CategoryId = productVM.CategoryId;
            product.GenderId = productVM.GenderId;
            product.PriceId = productVM.PriceId;
            product.Desc = productVM.Desc;
            product.Count = productVM.Count;
            product.StockStatus = productVM.StockStatus;
            product.TopItem = productVM.TopItem;
            product.RealPrice = productVM.RealPrice;
            if (productVM.ProductSizes != null)
            {
                foreach (int sizeId in productVM.ProductSizes)
                {
                    product.ProductSizes.Add(new ProductSize
                    {
                        ProductId = product.Id,
                        SizeId = sizeId
                    });
                }
            }

            await _context.SaveChangesAsync();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["PriceId"] = new SelectList(_context.Prices, "Id", "MinPrice");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await GetProductById(id);

            if (product == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/product", product.Image);

            Helper.DeleteFile(path);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<Product> GetProductById(int id)
        {
            return _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
