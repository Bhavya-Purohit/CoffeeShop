using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubcategoriesAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 4, "https://www.allrecipes.com/thmb/kTq3rdclrgW3U30RlND_QCMifnQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/What-Is-a-Mocktail-4x3-05a75e02326d4cdb8c1f310c7ea8c983.jpg", "Mocktails", 1 },
                    { 5, "https://th.bing.com/th/id/OIP.obyUm91cu_jAtnrJPxSAGwHaEi?rs=1&pid=ImgDetMain", "Soft Drinks", 1 },
                    { 6, "https://th.bing.com/th/id/OIP.bkIw6G3GakAWI8VEjp1AKwHaFN?w=1280&h=901&rs=1&pid=ImgDetMain", "Tea", 1 },
                    { 7, "https://th.bing.com/th/id/R.3c67e53d682589dcb8ce02dd3ac1e20c?rik=LeUqj%2bnBd3%2f0WA&riu=http%3a%2f%2fwallup.net%2fwp-content%2fuploads%2f2017%2f11%2f17%2f239445-coffee-coffee_beans-cup.jpg&ehk=%2bEd%2bhMjaHGMrExklwM9MNbALfkaDNqvDmS67gs%2bf2OA%3d&risl=&pid=ImgRaw&r=0", "Coffee", 1 },
                    { 8, "https://th.bing.com/th/id/OIP.8HPVNhrfz1Y-hVBokGwUiQHaEK?rs=1&pid=ImgDetMain", "Matcha", 1 },
                    { 9, "https://imgeng.jagran.com/images/2023/sep/healthy-juices1693713856763.jpg", "Juices", 1 },
                    { 10, "https://img.freepik.com/premium-photo/variety-smoothies-are-display-front-wooden-table_265515-6931.jpg", "Smoothies", 1 },
                    { 11, "https://th.bing.com/th/id/R.7d973c7f0e96d9c0c1388e2862008bf0?rik=vLG%2fD9Hh3wS7PA&riu=http%3a%2f%2fdontchangemuch.ca%2fwp-content%2fuploads%2f2014%2f04%2favoid-salty-snacks-600x400.jpg&ehk=3NoWPEt7TopX287Casw%2b4f7ddQFyTyjZRGVzmP0ftDs%3d&risl=&pid=ImgRaw&r=0", "Salty Snacks", 2 },
                    { 12, "https://th.bing.com/th/id/OIP.7Au8sSgD3sKhERqekJXWVgHaE6?rs=1&pid=ImgDetMain", "Sweet Snacks", 2 },
                    { 13, "https://drop.ndtv.com/albums/COOKS/5-quick-snacks-_638097489443661172/638097489474374702.png", "Quick Snacks", 2 },
                    { 14, "https://cdn.shopify.com/s/files/1/0587/2045/2783/files/Best_Vegan_Snacks.jpg?v=1657782422", "Vegan Snacks", 2 },
                    { 15, "https://familyapp.com/wp-content/uploads/2022/07/25-amazing-ideas-for-gluten-free-snacks.jpg", "Gluten Free Snacks", 2 },
                    { 16, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Pies-and-Cobblers.jpg", "Pies & Cobblers", 3 },
                    { 17, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Cookies.jpg", "Cookies", 3 },
                    { 18, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Cakes.jpg", "Cakes", 3 },
                    { 19, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Tarts.jpg", "Tarts", 3 },
                    { 20, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Ice-Cream.jpg", "Ice Cream", 3 },
                    { 21, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Custard.jpg", "Custards", 3 },
                    { 22, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Brownies.jpg", "Brownies", 3 },
                    { 23, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Pastries.jpg", "Pastries", 3 },
                    { 24, "https://insanelygoodrecipes.com/wp-content/uploads/2022/12/Donuts.jpg", "Donuts", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 9, 4, "This drink, sweetened with honey syrup, serves up all the winter vibes. Mix up a big batch in a pitcher for everyone to enjoy at your next gathering! This drink is also great for summer weather as a refreshing pick-me-up.", "https://img.buzzfeed.com/buzzfeed-static/static/2022-12/8/19/asset/70b89f8abc55/sub-buzz-1147-1670529545-28.jpg?downsize=700%3A%2A&output-quality=auto&output-format=auto", false, "Cranberry Rosemary Herb Soda", 150m },
                    { 10, 4, "With the rich flavors of black cherry juice, cola, and blackberry syrup, this dark and mysterious drink is taken to the next level with the magical effect of dry ice. Garnished with fresh blackberries, it’s as delicious as it is dramatic.", "https://mybartender.com/wp-content/uploads/2024/10/Black-Cauldron-Mocktail-1536x858.png", false, "Black Cauldron Mocktail", 120m },
                    { 11, 4, "With a blend of apple juice, tangy lemon juice, a hint of sweetness from granny smith apple syrup, and served over ice, this mocktail is a burst of crisp flavors.", "https://cf.ltkcdn.net/cocktails/images/std-xs/283957-340x227-mocktail-appletini.jpg", false, "Appletini Mocktail", 160m },
                    { 12, 5, "Soft Drink", "https://businesschronicler.com/wp-content/uploads/2022/09/Coca-Cola-Business-History-950x650.png", false, "Coca-Cola ", 150m },
                    { 13, 5, "Soft Drink", "https://creativereview.imgix.net/content/uploads/2023/03/pepsi-branding-1.jpg?auto=compress,format&q=60&w=1920&h=1435", false, "Pepsi", 120m },
                    { 14, 5, "Soft Drink", "https://etimg.etb2bimg.com/photo/89492209.cms", false, "Thumbs Up", 160m },
                    { 15, 6, "Soft Drink", "https://brewbuch.com/wp-content/uploads/2023/05/black-tea.jpg", false, "Black Tea", 160m },
                    { 16, 6, "Soft Drink", "https://brewbuch.com/wp-content/uploads/2023/05/green-tea.jpg", false, "Green Tea", 160m },
                    { 17, 6, "Soft Drink", "https://brewbuch.com/wp-content/uploads/2023/05/herbal-tea.jpg", false, "Herbal Tea", 160m },
                    { 18, 8, "Matcha", "https://www.tastingtable.com/img/gallery/ceremonial-grade-matcha-vs-culinary-grade-matcha-whats-the-difference/l-intro-1658943956.jpg", false, "Ceremonial Grade", 160m },
                    { 19, 8, "Matcha", "https://thumbor.forbes.com/thumbor/fit-in/900x510/https://www.forbes.com/health/wp-content/uploads/2022/03/960x0.jpeg.jpg", false, "Premium Grade", 160m },
                    { 20, 8, "Matcha", "https://cdn.shopify.com/s/files/1/2531/9554/files/culinary-grade-matcha-for-baking.jpg?v=1557956137", false, "Culinary Grade", 160m },
                    { 21, 9, "Juice", "https://www.mashed.com/img/gallery/apple-juice-brands-ranked-worst-to-best/l-intro-1621953689.jpg", false, "Apple Juice", 160m },
                    { 22, 9, "Juice", "https://bing.com/th?id=OSK.ef8f9ead7c81789047deb52b38e77afc", false, "Mango Juice", 160m },
                    { 23, 9, "Juice", "https://cdn.shopify.com/s/files/1/0248/9496/3802/files/keep-watermelon-fresh.jpg?v=1675340625", false, "Watermelon Juice", 160m },
                    { 24, 10, "Smoothie", "https://www.thespruceeats.com/thmb/JHOfNdO8jq5TEteU3IEiGHusoJE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/blueberry-smoothie-2238438-16_Hero_1-0901a8305220460da963ef7b210629ea.jpg", false, "Blueberry Smoothie", 160m },
                    { 25, 10, "Smoothie", "https://brewbuch.com/wp-content/uploads/2023/05/green-tea.jpg", false, "Spinach Smoothie", 160m },
                    { 26, 10, "Smoothie", "https://reciperunner.com/wp-content/uploads/2014/01/StrawberrySpinachSmoothie2.jpg", false, "Peach Smoothie", 160m },
                    { 27, 11, "Salty Snack", "https://hips.hearstapps.com/hmg-prod/images/delish-roastedchickpeas-030-1590498769.jpg?crop=0.763xw:0.572xh;0.0417xw,0.332xh&resize=1200:*", false, "Roasted Chickpea", 160m },
                    { 28, 12, "Sweet Snack", "https://i1.wp.com/www.husbandsthatcook.com/wp-content/uploads/2016/02/no-bake-strawberry-cheesecake-parfaits.jpg?fit=2048%2C1365&ssl=1", false, "Strawberry Cheesecake Parfaits", 160m },
                    { 29, 13, "Salty Snack", "https://i.ytimg.com/vi/0rwn-434Bhk/maxresdefault.jpg", false, "Dahi Batata Puri Chaat", 160m },
                    { 30, 14, "Vegan Snack", "https://th.bing.com/th/id/OSK.49de4b523093a0694d4ac13f9e3f923f?w=184&h=127&rs=2&qlt=80&o=6&cdv=1&dpr=1.5&pid=16.1", false, "Guacamole and Crackers", 160m },
                    { 31, 15, "Gluten free Snack", "https://images-prod.healthline.com/hlcmsresource/images/AN_images/gluten-free-snacks-zucchini-pizza.jpg", false, "Bite-size zucchini pizza", 160m },
                    { 32, 16, "Pies and Cobblers", "https://th.bing.com/th/id/OSK.HEROqxFe_Y-DUBVz1tqT6in63fo7Z8PBfZWXVV_6cZfhdoU?w=312&h=200&c=7&rs=1&o=6&dpr=1.5&pid=SANGAM", false, "Apple Pie", 160m },
                    { 33, 17, "Cookie", "https://www.cookie-coach.co.uk/wp-content/uploads/cookie.jpg", false, "Chocolate Cookie", 160m },
                    { 34, 18, "Cakes", "https://png.pngtree.com/thumb_back/fw800/background/20240704/pngtree-a-delicious-black-forest-cake-image_15956356.jpg", false, "Black Forest Cake", 160m },
                    { 35, 19, "Tarts", "https://thumbs.dreamstime.com/b/healthy-eating-summer-vegetable-tart-close-up-horizontal-table-73594075.jpg", false, "Vegetable Tart", 160m },
                    { 36, 20, "   Ice creams", "https://www.foodrepublic.com/img/gallery/how-to-top-vanilla-ice-cream-with-hot-sauce-the-right-way/l-intro-1684539127.jpg", false, "Vanilla Ice Cream", 160m },
                    { 37, 21, "Custards", "https://www.tastingtable.com/img/gallery/17-types-of-custard-desserts-explained/clafoutis-1667413271.webp", false, "Clafoutis", 160m },
                    { 38, 22, "Brownie", "https://palm.southbeachdiet.com/wp-content/uploads/2018/06/black-bean-brownies.jpg", false, "Chocolate Chip Bownie", 160m },
                    { 39, 23, "Pastries", "https://www.vahrehvah.com/indianfood_org/wp-content/uploads/2010/09/1W25TRR12q.jpg", false, "Pineapple Pastry", 160m },
                    { 40, 24, "Donut", "https://www.tastingtable.com/img/gallery/20-popular-types-of-donuts-explained/apple-cider-1695055907.webp", false, "Apple Cider", 160m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 0);
        }
    }
}
