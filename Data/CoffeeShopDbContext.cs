using CoffeeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace CoffeeShop.Data
{
    public class CoffeeShopDbContext: IdentityDbContext
    {
        public CoffeeShopDbContext()
        {
        }

        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext>options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
       
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Beverages", ImageUrl = "https://foodsafetyworks.com/wp-content/uploads/2023/01/04_22_HERO2_NA_Cocktails_GettyImages-1145767236_1920x1280-1200x750.jpg", ParentCategoryId = null },
                new Category { Id = 2, Name = "Snacks", ImageUrl = "https://img.freepik.com/premium-photo/wide-selection-snacks-beer_127657-11986.jpg", ParentCategoryId = null },
                new Category { Id = 3, Name = "Desserts", ImageUrl = "https://tasteoffrancemag.com/wp-content/uploads/2023/01/shutterstock_2122346009-scaled.jpg", ParentCategoryId = null },

                //Beverages sub categories
                new Category { Id = 4, Name = "Mocktails", ImageUrl = "https://www.allrecipes.com/thmb/kTq3rdclrgW3U30RlND_QCMifnQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/What-Is-a-Mocktail-4x3-05a75e02326d4cdb8c1f310c7ea8c983.jpg", ParentCategoryId = 1 },
                new Category { Id = 5, Name = "Soft Drinks", ImageUrl = "https://th.bing.com/th/id/OIP.obyUm91cu_jAtnrJPxSAGwHaEi?rs=1&pid=ImgDetMain", ParentCategoryId = 1 },
                new Category { Id = 6, Name = "Tea", ImageUrl = "https://th.bing.com/th/id/OIP.bkIw6G3GakAWI8VEjp1AKwHaFN?w=1280&h=901&rs=1&pid=ImgDetMain", ParentCategoryId = 1 },
                new Category { Id = 7, Name = "Coffee", ImageUrl = "https://th.bing.com/th/id/R.3c67e53d682589dcb8ce02dd3ac1e20c?rik=LeUqj%2bnBd3%2f0WA&riu=http%3a%2f%2fwallup.net%2fwp-content%2fuploads%2f2017%2f11%2f17%2f239445-coffee-coffee_beans-cup.jpg&ehk=%2bEd%2bhMjaHGMrExklwM9MNbALfkaDNqvDmS67gs%2bf2OA%3d&risl=&pid=ImgRaw&r=0", ParentCategoryId = 1 },
                new Category { Id = 8, Name = "Matcha", ImageUrl = "https://th.bing.com/th/id/OIP.8HPVNhrfz1Y-hVBokGwUiQHaEK?rs=1&pid=ImgDetMain", ParentCategoryId = 1 },
                new Category { Id = 9, Name = "Juices", ImageUrl = "https://imgeng.jagran.com/images/2023/sep/healthy-juices1693713856763.jpg", ParentCategoryId = 1 },
                new Category { Id = 10, Name = "Smoothies", ImageUrl = "https://img.freepik.com/premium-photo/variety-smoothies-are-display-front-wooden-table_265515-6931.jpg", ParentCategoryId = 1 },

                //Snacks sub categories
                new Category { Id = 11, Name = "Salty Snacks", ImageUrl = "https://th.bing.com/th/id/R.7d973c7f0e96d9c0c1388e2862008bf0?rik=vLG%2fD9Hh3wS7PA&riu=http%3a%2f%2fdontchangemuch.ca%2fwp-content%2fuploads%2f2014%2f04%2favoid-salty-snacks-600x400.jpg&ehk=3NoWPEt7TopX287Casw%2b4f7ddQFyTyjZRGVzmP0ftDs%3d&risl=&pid=ImgRaw&r=0", ParentCategoryId = 2 },
                new Category { Id = 12, Name = "Sweet Snacks", ImageUrl = "https://th.bing.com/th/id/OIP.7Au8sSgD3sKhERqekJXWVgHaE6?rs=1&pid=ImgDetMain", ParentCategoryId = 2 },
                new Category { Id = 13, Name = "Quick Snacks", ImageUrl = "https://drop.ndtv.com/albums/COOKS/5-quick-snacks-_638097489443661172/638097489474374702.png", ParentCategoryId = 2 },
                new Category { Id = 14, Name = "Vegan Snacks", ImageUrl = "https://cdn.shopify.com/s/files/1/0587/2045/2783/files/Best_Vegan_Snacks.jpg?v=1657782422", ParentCategoryId = 2 },
                new Category { Id = 15, Name = "Gluten Free Snacks", ImageUrl = "https://familyapp.com/wp-content/uploads/2022/07/25-amazing-ideas-for-gluten-free-snacks.jpg", ParentCategoryId = 2 },

                //Desserts sub categories
                new Category { Id = 16, Name = "Pies & Cobblers", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Pies-and-Cobblers.jpg", ParentCategoryId = 3 },
                new Category { Id = 17, Name = "Cookies", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Cookies.jpg", ParentCategoryId = 3 },
                new Category { Id = 18, Name = "Cakes", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Cakes.jpg", ParentCategoryId = 3 },
                new Category { Id = 19, Name = "Tarts", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Tarts.jpg", ParentCategoryId = 3 },
                new Category { Id = 20, Name = "Ice Cream", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Ice-Cream.jpg", ParentCategoryId = 3 },
                new Category { Id = 21, Name = "Custards", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Custard.jpg", ParentCategoryId = 3 },
                new Category { Id = 22, Name = "Brownies", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Brownies.jpg", ParentCategoryId = 3 },
                new Category { Id = 23, Name = "Pastries", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Pastries.jpg", ParentCategoryId = 3 },
                new Category { Id = 24, Name = "Donuts", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Donuts.jpg", ParentCategoryId = 3 }
            );

            // Configure Category relationship for subcategories (already correct)
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

    
            modelBuilder.Entity<Product>().HasData(


                //BEVERAGE PRODUCTS

                  //Mocktails
                  new Product { Id = 9, Name = "Cranberry Rosemary Herb Soda", Detail = "This drink, sweetened with honey syrup, serves up all the winter vibes. Mix up a big batch in a pitcher for everyone to enjoy at your next gathering! This drink is also great for summer weather as a refreshing pick-me-up.", Price = 150, ImageUrl = "https://img.buzzfeed.com/buzzfeed-static/static/2022-12/8/19/asset/70b89f8abc55/sub-buzz-1147-1670529545-28.jpg?downsize=700%3A%2A&output-quality=auto&output-format=auto", CategoryId = 4 },
                  new Product { Id = 10, Name = "Black Cauldron Mocktail", Detail = "With the rich flavors of black cherry juice, cola, and blackberry syrup, this dark and mysterious drink is taken to the next level with the magical effect of dry ice. Garnished with fresh blackberries, it’s as delicious as it is dramatic.", Price = 120, ImageUrl = "https://mybartender.com/wp-content/uploads/2024/10/Black-Cauldron-Mocktail-1536x858.png", CategoryId = 4 },
                  new Product { Id = 11, Name = "Appletini Mocktail", Detail = "With a blend of apple juice, tangy lemon juice, a hint of sweetness from granny smith apple syrup, and served over ice, this mocktail is a burst of crisp flavors.", Price = 160, ImageUrl = "https://cf.ltkcdn.net/cocktails/images/std-xs/283957-340x227-mocktail-appletini.jpg", CategoryId = 4 },

                 //Soft Drinks
                 new Product { Id = 12, Name = "Coca-Cola ", Detail = "Soft Drink", Price = 150, ImageUrl = "https://businesschronicler.com/wp-content/uploads/2022/09/Coca-Cola-Business-History-950x650.png", CategoryId = 5 },
                 new Product { Id = 13, Name = "Pepsi", Detail = "Soft Drink", Price = 120, ImageUrl = "https://creativereview.imgix.net/content/uploads/2023/03/pepsi-branding-1.jpg?auto=compress,format&q=60&w=1920&h=1435", CategoryId = 5 },
                 new Product { Id = 14, Name = "Thumbs Up", Detail = "Soft Drink", Price = 160, ImageUrl = "https://etimg.etb2bimg.com/photo/89492209.cms", CategoryId = 5 },

                  //Tea
                  new Product { Id = 15, Name = "Black Tea", Detail = "Soft Drink", Price = 160, ImageUrl = "https://brewbuch.com/wp-content/uploads/2023/05/black-tea.jpg", CategoryId = 6 },
                  new Product { Id = 16, Name = "Green Tea", Detail = "Soft Drink", Price = 160, ImageUrl = "https://brewbuch.com/wp-content/uploads/2023/05/green-tea.jpg", CategoryId = 6 },
                  new Product { Id = 17, Name = "Herbal Tea", Detail = "Soft Drink", Price = 160, ImageUrl = "https://brewbuch.com/wp-content/uploads/2023/05/herbal-tea.jpg", CategoryId = 6 },


                  //Coffee
                  new Product { Id = 1, Name = "Americano", Detail = "The Americano coffee is a classic espresso-based drink that is simple yet satisfying. It is made by adding hot water to a shot of espresso, which dilutes the intensity and results in a rich, bold coffee with a smooth finish. This versatile drink can be enjoyed on its own or with a splash of cream, making it a popular choice for coffee lovers everywhere. Whether you need a pick-me-up in the morning or a midday boost, the Americano is a dependable choice that never fails to deliver.", Price = 25, IsTrendingProduct = false, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704066/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/americano_gorkrx.png", CategoryId = 1 },
                  new Product { Id = 2, Name = "Cortado", Detail = "Cortado coffee is a traditional Spanish coffee beverage that has gained popularity worldwide. It is a smooth and creamy coffee that combines equal parts of espresso and warm milk, creating a perfect balance of intense coffee flavor and rich creaminess. This coffee is perfect for coffee lovers who want a bit of sweetness in their coffee without sacrificing its robust flavor. Cortado coffee is made using high-quality espresso beans, freshly brewed and combined with steamed milk to create a velvety, smooth and flavorful coffee. Whether you are a coffee aficionado or a coffee lover, Cortado coffee is the perfect coffee to start your day with or to enjoy in the afternoon. Try our Cortado coffee today and experience the unique and satisfying taste of this traditional Spanish coffee beverage.", Price = 25, IsTrendingProduct = true, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704067/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/cortado_rs5lwa.png", CategoryId = 1 },
                  new Product { Id = 3, Name = "Mocha", Detail = "Mocha coffee is a rich and creamy blend that combines the bold flavor of coffee with the sweetness of chocolate. This delectable drink is perfect for those who love the taste of chocolate but also enjoy a good coffee. Mocha coffee is made with a shot of espresso, steamed milk, and chocolate syrup. The result is a smooth and creamy drink with a sweet, chocolatey taste and a strong coffee finish. Whether you are looking for a sweet and indulgent treat or a pick-me-up in the morning, Mocha coffee is sure to satisfy your cravings. Get your fix of this delicious drink today and experience the perfect marriage of coffee and chocolate!", Price = 22, IsTrendingProduct = false, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704066/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/mocha_a80hlu.png", CategoryId = 1 },
                  new Product { Id = 4, Name = "Macchiato", Detail = "Macchiato Coffee is a classic espresso-based beverage with a rich, creamy flavor and a smooth, velvety texture. Made from high-quality, hand-selected coffee beans, this drink is the perfect pick-me-up for coffee lovers who want a strong, bold taste without the bitterness or harshness of traditional espresso. With a layer of dense, frothed milk that sits on top of the shot of espresso, the Macchiato Coffee is the perfect balance of bold coffee flavor and creamy sweetness. Whether you're a busy professional in need of a morning boost, or an espresso aficionado seeking a more refined coffee experience, the Macchiato Coffee is the ultimate choice for anyone who loves coffee. So why wait? Visit our online coffee store today and try a Macchiato Coffee today!", Price = 15, IsTrendingProduct = true, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704064/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/macchiato_jelmpv.png", CategoryId = 1 },
                  new Product { Id = 5, Name = "Flat White", Detail = "Flat White Coffee is a classic espresso-based beverage that is a staple in coffee shops all over the world. This smooth and creamy coffee is made with perfectly pulled shots of espresso, topped with velvety steamed milk and a thin layer of microfoam. This gives the Flat White its signature smooth and creamy texture and a rich, coffee flavor that is balanced by the sweetness of the milk. The Flat White is a perfect coffee for those who love a strong coffee taste with a hint of sweetness. Whether you are a coffee aficionado or just looking for a delicious coffee to start your day, a Flat White from our store is the perfect choice!", Price = 18, IsTrendingProduct = false, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704064/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/flat-white_icl8cr.png", CategoryId = 1 },
                  new Product { Id = 6, Name = "Decaf", Detail = "Decaf Coffee, also known as decaffeinated coffee, is a coffee beverage that has had the majority of its caffeine content removed. It is a perfect option for those who enjoy the taste and aroma of coffee, but want to avoid the stimulating effects of caffeine. Decaf coffee is made from 100% Arabica beans, which are carefully roasted to bring out their natural sweetness and rich flavor. Whether you're a coffee aficionado or just looking for a comforting cup of joe, decaf coffee is the perfect choice. It offers all the delicious taste of regular coffee, without the caffeine jitters, making it an ideal choice for late-night sipping, morning or afternoon pick-me-ups, or simply whenever you want to relax and enjoy a cup of coffee. So why wait? Treat yourself to a delicious cup of decaf coffee today and enjoy the taste of coffee, without the caffeine.", Price = 25, IsTrendingProduct = false, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704069/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/decaf-coffee_p3bth2.png", CategoryId = 1 },
                  new Product { Id = 7, Name = "Irish Coffee", Detail = "Irish coffee is a warm, comforting drink that combines the bold flavor of coffee with the smooth sweetness of Irish whiskey and a touch of cream. Our version of this classic cocktail is made with rich, bold coffee and the finest Irish whiskey for a perfect balance of flavors. The cream is gently whipped to a smooth consistency and poured over the coffee, creating a luxurious, creamy layer that balances the whiskey’s warmth. Whether you’re looking for a cozy drink on a cold day or a fun nightcap after a night out, Irish coffee is a perfect choice. Order yours today and experience the perfect blend of coffee and whiskey.", Price = 15, IsTrendingProduct = true, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704079/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/Irish_Coffee_ncjb0t.png", CategoryId = 1 },
                  new Product { Id = 8, Name = "Iced Coffee", Detail = "Iced coffee is a refreshing and delicious way to enjoy your coffee, perfect for hot summer days or for anyone looking for a cool pick-me-up. Our iced coffee is made with high-quality, freshly brewed coffee, which is then chilled and served over ice. We use only the finest coffee beans, expertly roasted to bring out their rich, full-bodied flavor, ensuring that every sip is a treat. Our iced coffee is available in a variety of flavors, including classic black, vanilla, caramel, and mocha, making it the perfect choice for coffee lovers of all tastes. So why wait? Treat yourself to a cold, refreshing glass of iced coffee today!", Price = 13, IsTrendingProduct = false, ImageUrl = "https://res.cloudinary.com/durcypdqc/image/upload/v1675704079/Coffee%20Shop%20Asp%20.NET%20Core%20Assets/Iced_Coffee_o2nenz.png", CategoryId = 1 },

                  //Matcha
                  new Product { Id = 18, Name = "Ceremonial Grade", Detail = "Matcha", Price = 160, ImageUrl = "https://www.tastingtable.com/img/gallery/ceremonial-grade-matcha-vs-culinary-grade-matcha-whats-the-difference/l-intro-1658943956.jpg", CategoryId = 8 },
                  new Product { Id = 19, Name = "Premium Grade", Detail = "Matcha", Price = 160, ImageUrl = "https://thumbor.forbes.com/thumbor/fit-in/900x510/https://www.forbes.com/health/wp-content/uploads/2022/03/960x0.jpeg.jpg", CategoryId = 8 },
                  new Product { Id = 20, Name = "Culinary Grade", Detail = "Matcha", Price = 160, ImageUrl = "https://cdn.shopify.com/s/files/1/2531/9554/files/culinary-grade-matcha-for-baking.jpg?v=1557956137", CategoryId = 8 },

                  //Juices
                  new Product { Id = 21, Name = "Apple Juice", Detail = "Juice", Price = 160, ImageUrl = "https://www.mashed.com/img/gallery/apple-juice-brands-ranked-worst-to-best/l-intro-1621953689.jpg", CategoryId = 9 },
                  new Product { Id = 22, Name = "Mango Juice", Detail = "Juice", Price = 160, ImageUrl = "https://bing.com/th?id=OSK.ef8f9ead7c81789047deb52b38e77afc", CategoryId = 9 },
                  new Product { Id = 23, Name = "Watermelon Juice", Detail = "Juice", Price = 160, ImageUrl = "https://cdn.shopify.com/s/files/1/0248/9496/3802/files/keep-watermelon-fresh.jpg?v=1675340625", CategoryId = 9 },

                  //Smoothies
                  new Product { Id = 24, Name = "Blueberry Smoothie", Detail = "Smoothie", Price = 160, ImageUrl = "https://www.thespruceeats.com/thmb/JHOfNdO8jq5TEteU3IEiGHusoJE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/blueberry-smoothie-2238438-16_Hero_1-0901a8305220460da963ef7b210629ea.jpg", CategoryId = 10 },
                  new Product { Id = 25, Name = "Spinach Smoothie", Detail = "Smoothie", Price = 160, ImageUrl = "https://brewbuch.com/wp-content/uploads/2023/05/green-tea.jpg", CategoryId = 10 },
                  new Product { Id = 26, Name = "Peach Smoothie", Detail = "Smoothie", Price = 160, ImageUrl = "https://reciperunner.com/wp-content/uploads/2014/01/StrawberrySpinachSmoothie2.jpg", CategoryId = 10 },



                  //SNACKS PRODUCTS

                  //Salty Snacks
                  new Product { Id = 27, Name = "Roasted Chickpea", Detail = "Salty Snack", Price = 160, ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/delish-roastedchickpeas-030-1590498769.jpg?crop=0.763xw:0.572xh;0.0417xw,0.332xh&resize=1200:*", CategoryId = 11 },

                  //Sweet Snacks
                  new Product { Id = 28, Name = "Strawberry Cheesecake Parfaits", Detail = "Sweet Snack", Price = 160, ImageUrl = "https://i1.wp.com/www.husbandsthatcook.com/wp-content/uploads/2016/02/no-bake-strawberry-cheesecake-parfaits.jpg?fit=2048%2C1365&ssl=1", CategoryId = 12 },

                  //Quick Snacks
                  new Product { Id = 29, Name = "Dahi Batata Puri Chaat", Detail = "Salty Snack", Price = 160, ImageUrl = "https://i.ytimg.com/vi/0rwn-434Bhk/maxresdefault.jpg", CategoryId = 13 },

                  //Vegan Snacks
                  new Product { Id = 30, Name = "Guacamole and Crackers", Detail = "Vegan Snack", Price = 160, ImageUrl = "https://th.bing.com/th/id/OSK.49de4b523093a0694d4ac13f9e3f923f?w=184&h=127&rs=2&qlt=80&o=6&cdv=1&dpr=1.5&pid=16.1", CategoryId = 14 },

                  //Gluten free Snack
                  new Product { Id = 31, Name = "Bite-size zucchini pizza", Detail = "Gluten free Snack", Price = 160, ImageUrl = "https://images-prod.healthline.com/hlcmsresource/images/AN_images/gluten-free-snacks-zucchini-pizza.jpg", CategoryId = 15 },


                //DESSERTS PRODUCTS

                  //Pies & Cobblers
                  new Product { Id = 32, Name = "Apple Pie", Detail = "Pies and Cobblers", Price = 160, ImageUrl = "https://th.bing.com/th/id/OSK.HEROqxFe_Y-DUBVz1tqT6in63fo7Z8PBfZWXVV_6cZfhdoU?w=312&h=200&c=7&rs=1&o=6&dpr=1.5&pid=SANGAM", CategoryId = 16 },

                  //Cookies
                  new Product { Id = 33, Name = "Chocolate Cookie", Detail = "Cookie", Price = 160, ImageUrl = "https://www.cookie-coach.co.uk/wp-content/uploads/cookie.jpg", CategoryId = 17 },


                  //Cakes
                  new Product { Id = 34, Name = "Black Forest Cake", Detail = "Cakes", Price = 160, ImageUrl = "https://png.pngtree.com/thumb_back/fw800/background/20240704/pngtree-a-delicious-black-forest-cake-image_15956356.jpg", CategoryId = 18 },

                  //Tarts
                  new Product { Id = 35, Name = "Vegetable Tart", Detail = "Tarts", Price = 160, ImageUrl = "https://thumbs.dreamstime.com/b/healthy-eating-summer-vegetable-tart-close-up-horizontal-table-73594075.jpg", CategoryId = 19 },

                  //Ice Cream
                  new Product { Id = 36, Name = "Vanilla Ice Cream", Detail = "   Ice creams", Price = 160, ImageUrl = "https://www.foodrepublic.com/img/gallery/how-to-top-vanilla-ice-cream-with-hot-sauce-the-right-way/l-intro-1684539127.jpg", CategoryId = 20 },

                  //Custards
                  new Product { Id = 37, Name = "Clafoutis", Detail = "Custards", Price = 160, ImageUrl = "https://www.tastingtable.com/img/gallery/17-types-of-custard-desserts-explained/clafoutis-1667413271.webp", CategoryId = 21 },

                  //Brownies
                  new Product { Id = 38, Name = "Chocolate Chip Bownie", Detail = "Brownie", Price = 160, ImageUrl = "https://palm.southbeachdiet.com/wp-content/uploads/2018/06/black-bean-brownies.jpg", CategoryId = 22 },

                  //Pastries
                  new Product { Id = 39, Name = "Pineapple Pastry", Detail = "Pastries", Price = 160, ImageUrl = "https://www.vahrehvah.com/indianfood_org/wp-content/uploads/2010/09/1W25TRR12q.jpg", CategoryId = 23 },

                   //Donuts
                   new Product { Id = 40, Name = "Apple Cider", Detail = "Donut", Price = 160, ImageUrl = "https://www.tastingtable.com/img/gallery/20-popular-types-of-donuts-explained/apple-cider-1695055907.webp", CategoryId = 24 }





                );


        }
    }
}
