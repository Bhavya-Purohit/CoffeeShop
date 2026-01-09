using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Data;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CoffeeShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CoffeeShopDbContext _context;

        public CategoryController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //SubCategories
            var categories = _context.Categories
                                     .Include(c => c.SubCategories)
                                     .ToList();

            return View(categories);
        }
    }
}
