using System;

namespace HockeyShop1
{
    class Program
    {
        static void Main(string[] args)
        {
            // SELECT
            /*var products = DataBaseDapper.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Id} {prod.CategoryId} {prod.BrandId}  {prod.ModelName} {prod.Price}  {prod.Color} ");
            }*/
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            // INSERT
            /*var newProduct = new Models.Product
            {
                CategoryId = 1,
                BrandId = 1,
                ModelName ="Super Tacks X",
                Color = "Black",
                Price = 3999
            };
            // UPDATE
            int affectedRows = DataBaseDapper.InsertProduct(newProduct);
            Console.WriteLine($"A new product was added to the list {affectedRows}");*/

            /*var updateProduct = DataBaseDapper.UpdateProduct(3999, 15);
            Console.WriteLine($"Product updated in the list {updateProduct}");*/

            var menu = new Menu();
            menu.Run();
            Console.ReadKey(true);

        }
    }
}
