using CoffeeShop.Data;
using CoffeeShop.Models;
using CoffeeShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CoffeeShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly CoffeeShopDbContext _context;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public AdminController(CoffeeShopDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            _context = context;
            
            
        }


        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalUsers = _context.Users.Count(),
                TotalOrders = _context.Orders.Count(),
                TotalRevenue = _context.Orders.Sum(o => o.OrderTotal),
                NewOrders = _context.Orders.Where(o => o.OrderPlaced.Month == DateTime.Now.Month).Count(),
                GrowthRate = CalculateGrowthRate() // Your method to calculate growth rate
               
            };
            return View(model);
        }

        private decimal CalculateGrowthRate()
        {
            // Get the total orders for the last month and the month before that
            var lastMonth = DateTime.Now.AddMonths(-1);
            var lastMonthTotal = _context.Orders
                .Count(o => o.OrderPlaced.Year == lastMonth.Year && o.OrderPlaced.Month == lastMonth.Month);

            var monthBeforeLast = DateTime.Now.AddMonths(-2);
            var monthBeforeLastTotal = _context.Orders
                .Count(o => o.OrderPlaced.Year == monthBeforeLast.Year && o.OrderPlaced.Month == monthBeforeLast.Month);

            // Calculate growth rate
            if (monthBeforeLastTotal == 0)
            {
                return lastMonthTotal > 0 ? 1 : 0; // If no orders in the month before last, return 100% growth if there are orders this month
            }

            return (decimal)(lastMonthTotal - monthBeforeLastTotal) / monthBeforeLastTotal; // Calculate growth rate
        }

        public async Task<IActionResult> ManageProducts()
        {
            var products = await _context.Products.ToListAsync();

            // You can check for nulls here if you need to
            foreach (var product in products)
            {
                // Ensure that Detail is not null
                product.Detail = product.Detail ?? "No description available."; // Optional fallback
            }

            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChangesAsync();

                // Store a confirmation message
                TempData["Message"] = "New product successfully added.";

                return RedirectToAction("ManageProducts");
            }
            return View(product);
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(ManageProducts));
            }
            return View(product);
        }


        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);  // This returns a view where you can confirm deletion.
        }


        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();


            // Store a confirmation message
            TempData["Message"] = "Product successfully deleted."; 

            return RedirectToAction(nameof(ManageProducts));
        }




        public IActionResult ManageOrders()
        {
            var orders = _context.Orders.Include(o => o.OrderDetails).ToList();
            return View(orders);
        }

        public IActionResult ViewOrder(int id)
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("ManageOrders"); // Redirect back to ManageOrders after deleting
        }

        public IActionResult EditOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrder(Order updatedOrder)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedOrder);
            }

            var order = _context.Orders.FirstOrDefault(o => o.Id == updatedOrder.Id);
            if (order == null)
            {
                return NotFound();
            }

            // Update the fields
            order.OrderStatus = updatedOrder.OrderStatus;
            order.TrackingNumber = updatedOrder.TrackingNumber;
            order.FirstName = updatedOrder.FirstName;
            order.LastName = updatedOrder.LastName;

            _context.SaveChanges();
            return RedirectToAction("ManageOrders");
        }


       // public async Task<IActionResult> ManageUsers()
        //{
          //  var users = await _userManager.Users.ToListAsync();
            //var userViewModels = users.Select(user => new UserViewModel
            //{
              //  Id = user.Id,
                //UserName = user.UserName,
                //Email = user.Email,
                
            //}).ToList();

            //return View(userViewModels);
        //}


        // Add methods for creating, updating, deleting products and orders
    }
}
