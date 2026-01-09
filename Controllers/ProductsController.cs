
using CoffeeShop.Data;
using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CoffeeShop.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        private readonly CoffeeShopDbContext _context;

        public ProductsController(IProductRepository productRepository, CoffeeShopDbContext context)
        {
            this.productRepository = productRepository;
            this._context = context;
        }

        public IActionResult Shop()
        {
            var categories = _context.Categories
        .Where(c => c.ParentCategoryId == null)
        .Include(c => c.SubCategories)  //Eager load subcategories
        .ToList();

            return View(categories);
        }


        public IActionResult Detail(int id)
        {
            
            
                var product = productRepository.GetProductDetail(id);
                if(product==null)
                {
                    return NotFound();
                }
                 return View(product);
        
        }

        public IActionResult AddProductToOrder(int orderId, int productId)
        {
            // Logic to add the product to the order
           // _orderService.AddProductToOrder(orderId, productId);
            return RedirectToAction("OrderTracking", "Order", new { id = orderId });
        }

        // Show all categories
        public IActionResult Categories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Show products by selected category
        public IActionResult ProductsBySubCategory(int Id)
       
        {
            var products = _context.Products
               // .Where(p => p.CategoryId == CategoryId)
                .ToList();

            ViewBag.SubCategoryName = _context.Categories.Find(Id)?.Name;

            return View(products);
        }




        public IActionResult SubCategories(int id)
        {
            var parentCategory = _context.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefault(c => c.Id == id);

            if (parentCategory == null)
            {
                return NotFound();
            }

            return View(parentCategory);
        }

        public IActionResult ByCategory(int id)
        {
            var products = _context.Products
                .Where(p => p.CategoryId == id)
                .ToList();

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            ViewBag.CategoryName = category?.Name;

            return View(products);
        }

    }
}
