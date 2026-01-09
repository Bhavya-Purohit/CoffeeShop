using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using CoffeeShop.Data;

namespace CoffeeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var items = shoppingCartRepository.GetShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;

            // Pass cartCount and cart total to the view
            ViewBag.CartTotal = shoppingCartRepository.GetShoppingCartTotal();
            ViewBag.CartCount = HttpContext.Session.GetInt32("CartCount") ?? 0;

            return View(items);
        }

        public RedirectToActionResult AddToShoppingCart(int pId)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
            if (product != null)
            {
                shoppingCartRepository.AddToCart(product);

                // Update cartCount in session
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Count;
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pId)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
            if (product != null)
            {
                shoppingCartRepository.RemoveFromCart(product);

                // Update cartCount in session
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Count;
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            // Logic to update the quantity of the product in the cart
            var items = shoppingCartRepository.GetShoppingCartItems();
            var item = items.FirstOrDefault(i => i.Product.Id == productId);

            if (item != null)
            {
                item.Oty = quantity;
                shoppingCartRepository.ShoppingCartItems = items;

                // Update cartCount in session
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Sum(i => i.Oty);
                HttpContext.Session.SetInt32("CartCount", cartCount);

                // Calculate and return the updated total price
                decimal newCartTotal = shoppingCartRepository.GetShoppingCartTotal();
                return Json(new { newCartTotal, cartCount });
            }

            return BadRequest();
        }

      
           
        }

    }

