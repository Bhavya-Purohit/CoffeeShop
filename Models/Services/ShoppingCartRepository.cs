using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private CoffeeShopDbContext dbContext;
        public ShoppingCartRepository(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public string? ShoppingCartId { get; set; }


        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            CoffeeShopDbContext context = services.GetService<CoffeeShopDbContext>() ?? throw new Exception("Error initializing coffeeshopdbcontext");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };

        }




        public void AddToCart(Product product)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                        Product = product,
                        Oty = 1
                };
                dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Oty++;
            }
            dbContext.SaveChanges();
        }




         public void ClearCart()
        {
            var cartItems = dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);
            dbContext.ShoppingCartItems.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
           return ShoppingCartItems ??= dbContext.ShoppingCartItems.Where(s =>s.ShoppingCartId == ShoppingCartId)
                .Include(p => p.Product).ToList();
        }

        public decimal GetShoppingCartTotal()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var totalCost = dbContext.ShoppingCartItems.Where(s=>s.ShoppingCartId == ShoppingCartId)
                .Select(s=>s.Product.Price * s.Oty).Sum();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return totalCost;
        }

        public int RemoveFromCart(Product product)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var quantity = 0;

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Oty > 1)
                {
                    shoppingCartItem.Oty--;
                    quantity = shoppingCartItem.Oty;
                }
                else
                {
                    dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            dbContext.SaveChanges();
            return quantity;
        }
    }
}
