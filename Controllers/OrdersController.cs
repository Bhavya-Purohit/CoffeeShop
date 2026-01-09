using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Data;

namespace CoffeeShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCartRepository shopCartRepository;
        private readonly CoffeeShopDbContext _context;

        // Consolidate dependencies in a single constructor
        public OrdersController(CoffeeShopDbContext context, IOrderRepository orderRepository, IShoppingCartRepository shopCartRepository)
        {
            _context = context;
            this.orderRepository = orderRepository;
            this.shopCartRepository = shopCartRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shopCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("OrderTracking", new { id = order.Id });
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }

        public IActionResult OrderTracking(int id)
        {
            // Retrieve the order with the given ID
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);

            // Check if order exists
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return View(order); // Assumes a view called OrderTracking.cshtml
        }


        public IActionResult OrderSummary(int orderId)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product) // Include related Product data
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }



        // public IActionResult AddProductToOrder(int orderId, int productId)
        //{
        // Logic to add the product to the order
        //   _orderService.AddProductToOrder(orderId, productId);
        // return RedirectToAction("OrderTracking", new { id = orderId });
        //}
    }
}

