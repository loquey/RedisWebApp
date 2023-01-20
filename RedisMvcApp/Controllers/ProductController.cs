﻿using Microsoft.AspNetCore.Mvc;

using RedisMvcApp.Models.Products;
using RedisMvcApp.Persistence;
using RedisMvcApp.Persistence.Entities;

namespace RedisMvcApp.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        { return View(); }

        public IActionResult ViewProduct()
        { return View(); }


        public IActionResult DeleteProduct() { return View(); }


        [HttpGet]
        public IActionResult AddProductCategory()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory(ProductCategoryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var product = new ProductCategory
            {
                CategoryDescription = model.CategoryDescription,
                CategoryName = model.CategoryName,
                ProductCategoryId = new ProductCategoryId(Guid.NewGuid())
            };

            _DbContext.Add(product);
            await _DbContext.SaveChangesAsync();

            return View();
        }

        public IActionResult ProductCagetories()
        {
            var products = _DbContext.ProductCategories.ToList();

            return View(products);
        }

        public IActionResult ProductSellers() { return View(); }
        public IActionResult AddProductSellers() { return View(); }

        private AppDbContext _DbContext;
    }
}
