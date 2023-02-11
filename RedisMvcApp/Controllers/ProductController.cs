using Microsoft.AspNetCore.Mvc;

using RedisMvcApp.Models.Products;
using RedisMvcApp.Persistence;
using RedisMvcApp.Persistence.Entities;

using StackExchange.Redis;

namespace RedisMvcApp.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(AppDbContext dbContext, ConnectionMultiplexer connectionMultiplexer)
        {
            _DbContext = dbContext;
            _ConnectionMultiplexer = connectionMultiplexer;
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

            var redisConn = _ConnectionMultiplexer.GetDatabase();
            await redisConn.HashSetAsync(model.CategoryName, "description", product.CategoryDescription, When.Always);
            await redisConn.HashSetAsync(model.CategoryName, "catid", product.ProductCategoryId.ToString(), When.Always);

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
        private ConnectionMultiplexer _ConnectionMultiplexer;
    }
}
