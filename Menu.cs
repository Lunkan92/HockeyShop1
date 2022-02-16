using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using HockeyShop1.Models;

namespace HockeyShop1
{
    class Menu
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog=HockeyShop1; persist security info=true; Integrated Security=true";
        //static string connString = "Server=tcp:newtondemo50.database.windows.net,1433;Initial Catalog=DemoDB;Persist Security Info=False;User ID=Admin50;Password=1992LunkaN;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=3000";


        public void Run()
        {

            int val = 0;
           
            do
            {

                Console.WriteLine("Welcome to our hockeyshop");
                Console.WriteLine("What do you want to do? Make a choice between 1-6.");
                Console.WriteLine("1. See all products");
                Console.WriteLine("2. See info about the product");
                Console.WriteLine("3. See shoppingcart");
                Console.WriteLine("4. Admin");
                Console.WriteLine("5. Search for a prodcut ");
                Console.WriteLine("6. Leave the shop");


                try
                {
                    val = int.Parse(Console.ReadLine());
                   
                }
                catch
                {
                    Console.WriteLine("Wrong input, choose between 1-6");
                }

                switch (val)
                {
                    case 1:
                        Console.Clear();
                        SeAllProducts();
                        Console.WriteLine();

                        break;
                    case 2:
                        Console.Clear();
                        SeAllProducts();
                        Console.WriteLine("What product would you like to learn more about? (Type in Id-number)");
                        SeeInfoAboutProduct();

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Show shoppingcart");
                        Console.WriteLine("-------------------");
                        SeeShoppingCart();
                        
                       
                     
         
                        int newMeny = 0;

                        do
                        {
                            Console.WriteLine("1. Add product to shoppingcart");
                            Console.WriteLine("2. Remove product from shoppingcart");
                            Console.WriteLine("3. Pay");
                            Console.WriteLine("4. Go back to menu");
                            try
                            {
                                newMeny = int.Parse(Console.ReadLine());

                            }
                            catch
                            {
                                Console.WriteLine("Wrong input, choose between 1-4");
                            }


                            switch (newMeny)
                            {
                                case 1:

                                    Console.Clear();
                                    SeAllProducts();
                                    Console.WriteLine("What product would you like to add? (Type in productID)");
                                    var addToCart = Convert.ToInt32(Console.ReadLine());
                                    AddProductToCart(addToCart);
                                    SeeShoppingCart();

                                  




                                    break;
                                case 2:
                                    Console.Clear();
                                    SeeShoppingCart();
                                    Console.WriteLine("What product do you want to remove? (Type in ID)");
                                    var removeFromCart = Convert.ToInt32(Console.ReadLine());
                                    RemoveProductFromCart(removeFromCart);
                                    SeeShoppingCart();
                                    break;

                                case 3:
                                    Console.Clear();
                                    SeeShoppingCart();
                                    Console.WriteLine("Would you like to pay with card or swish?(1 for card and 2 for swish)");
                                    var payment = int.Parse(Console.ReadLine());
                                    if (payment == 1)
                                    {
                                        Console.WriteLine("Write your cardnumber and press enter to pay");
                                        Console.ReadLine();
                                        Payment();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write your phonenumber and press enter to pay");
                                        Console.ReadLine();
                                        Payment();
                                    }
                                    break;

                                    
                                case 4:
                                    GoBackToMenu();
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Wrong input, choose between 1-4");
                                    break;


                            }

                        }
                        while (newMeny != 4);
                        break;


                    case 4:
                        Console.Clear();
                        int loginAttempts = 0;

                     
                        for (int i = 0; i < 3; i++)
                        {
                         
                            Console.WriteLine("Enter password");
                            string password = Console.ReadLine();

                            if (password != "FredrikFredric")
                                loginAttempts++;
                            else
                                break;
                        }

                   
                        if (loginAttempts > 2)
                            Console.WriteLine("Login failure");
                        else
                            Console.WriteLine("Login successful");
                        Console.ReadKey();
                        Console.Clear();
                        int adminMenu = 0;
                        do
                        {
                            Console.WriteLine("1. Add a new product to the assortment");
                            Console.WriteLine("2. Remove product from the assortment");
                            Console.WriteLine("3. Alter price on product in the assortment");
                            Console.WriteLine("4. Alter modelname on product in the assortment");
                            Console.WriteLine("5. Alter description on product in the assortment");
                            Console.WriteLine("6. Alter catergory on product in the assortment");
                            Console.WriteLine("7. Exit");
                            try
                            {
                                adminMenu = int.Parse(Console.ReadLine());

                            }
                            catch
                            {
                                Console.WriteLine("Wrong input, choose between 1-7");
                            }
                            switch (adminMenu)
                            {
                                case 1:
                                    Console.WriteLine("Please type in CategoryId,BrandId,ModelName,Color,Price,Description");
                                    var newProduct = new Product
                                    {
                                        CategoryId = int.Parse(Console.ReadLine()),
                                        BrandId = int.Parse(Console.ReadLine()),
                                        ModelName = Console.ReadLine(),
                                        Color = Console.ReadLine(),
                                        Price = int.Parse(Console.ReadLine()),
                                        Description = Console.ReadLine()

                                    };
                                    DataBaseDapper.AddProductAdmin(newProduct);
                                    break;
                                case 2:
                                    SeAllProducts();
                                    Console.WriteLine("\nPlease type in what product you want to remove (Use productID)");
                                   
                                    var removeProduct = int.Parse(Console.ReadLine());
                                    DataBaseDapper.RemoveProductAdmin(removeProduct);
                                    break;
                                case 3:
                                    SeAllProducts();
                                    Console.WriteLine("Change price on a product(Choose product with id)");
                                    var updatePriceOn = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("New price:");
                                    var newPriceOfProduct = float.Parse(Console.ReadLine());
                                    ChangeProductPrice(newPriceOfProduct, updatePriceOn);

                                    break;
                                case 4:SeAllProducts();
                                    Console.WriteLine("Change modelname on a product(Choose product with id)");
                                    var updateId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("New name:");
                                    var newName = Console.ReadLine();
                                    ChangeProductModelName(newName, updateId);
                                    break;

                                case 5:
                                    SeAllProducts();
                                    Console.WriteLine("Change description on a product(Choose product with id)");
                                    var updatedesp = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Write new description:");
                                    var newDesp = Console.ReadLine();

                                    ChangeProductDescription(updatedesp, newDesp);
                                    break;
                                case 6:
                                    SeAllProducts();
                                    Console.WriteLine("Change category on a product(Choose product with id)");
                                    var product = Convert.ToInt32(Console.ReadLine());
                                    SeeProductsForChangeCategory();
                                    Console.WriteLine("Choose which category the product should have:");
                                    var newCategory = Convert.ToInt32(Console.ReadLine());
                                    ChangeProductCategory(newCategory, product);
                                    
                                  

                                    break;

                                case 7:GoBackToMenu();
                                    break;
                                default:
                                    Console.WriteLine("Wrong input, choose between 1-7");
                                    break;
                            }

                        } while (adminMenu!=7);

                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Tpye in your search word");
                        SearchAndShowProducts();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        avsluta();
                        break;
                    default:
                        Console.WriteLine("Wrong input, choose between 1-5!");
                        break;
                }

            } while (val != 6);
        }
        public void avsluta()
        {
            Console.WriteLine("Leavning the shop");
        }

        public void GoBackToMenu()
        { }
        public static void SeeProductsForChangeCategory()
        {
            using (var db = new Models.HockeyShop1Context())
            {
                var change = from category in db.Categories
                             select category;
                foreach (var c in change)
                {
                    Console.WriteLine($"{c.Id} {c.CategoryName}");
                }

            }

        }
        // LINQ
        public static void SeAllProducts()
        {
            using (var db = new Models.HockeyShop1Context())
            {
                var prod = from prods in db.Products
                           join category in db.Categories on prods.CategoryId equals category.Id
                           join b in db.Brands on prods.BrandId equals b.Id
                           select new Products { Id = prods.Id, CategoryName = category.CategoryName, BrandName = b.BrandName, ModelName = prods.ModelName, Price = prods.Price, Color = prods.Color };
                
                foreach (var p in prod)
                {
                    Console.WriteLine($"Product ID:{p.Id} |\tCategory:{p.CategoryName}|\tBrand: {p.BrandName} |\tModel:{p.ModelName}|\tPrice: {p.Price}kr|\tColor:{p.Color} ");


                }

            }
        }
        //se mer info om produkter
        public static void SeeInfoAboutProduct()
        {
            using (var db = new Models.HockeyShop1Context())
            {

                var products = db.Products;

                var moreInfo = products.Where(products => products.Id == Convert.ToInt32(Console.ReadLine()));

                foreach (var prod in moreInfo)
                {
                    Console.WriteLine($"{prod.Id}\t{prod.ModelName}\t{prod.Description}");
                }


            }
        }

        // se varukorg
        public static void SeeShoppingCart()
        {
            using (var db = new Models.HockeyShop1Context())
            {
                

                var shoppingCart = from item in db.ShoppinCarts
                                   join prod in db.Products on item.ProductId equals prod.Id
                                   join category in db.Categories on prod.CategoryId equals category.Id
                                   join brand in db.Brands on prod.BrandId equals brand.Id
                                   select new Products { Id = prod.Id, Ids = item.Id, CategoryName = category.CategoryName, BrandName = brand.BrandName, ModelName = prod.ModelName, Price = prod.Price, Color = prod.Color };

                foreach (var p in shoppingCart)
                {
                    Console.WriteLine($"Product ID:{ p.Id}|\nID:{p.Ids} |\nCategory:{p.CategoryName}|\nBrand: {p.BrandName} |\nModel:{p.ModelName}|\nPrice: {p.Price}kr|\nColor:{p.Color} ");

                }
                

            }
        }

        /*public static List<Product> SeeCart()
        {
            var cart = new List<Product>();
            var sql = @" SELECT *from [Shoppin Cart] sh
                        join Products P on sh.ProductId = P.Id
                        join Categories c on P.CategoryId = c.Id
                        join Brand b on P.BrandId = b.Id ";
            using (var connetion = new SqlConnection(connString))
            {
                connetion.Open();
                cart = connetion.Query<Product>(sql).ToList();
            }
            return cart;

        }
        public static List<Product>SUM()
        {
            var totSum = new List<Product>();
            var sql = $@"SELECT SUM(Price) AS 'Total sum' FROM Products P 
                        JOIN [Shoppin Cart] SH ON P.Id = SH.ProductId";

            using (var connetion = new SqlConnection(connString))
            {
                
                totSum = connetion.Query<Product>(sql).ToList();

            }
            return totSum;
        }*/
       


        //Lägger till produkt i varukorgen
        public static int AddProductToCart(int addtocart1)
        {
            using (var db = new Models.HockeyShop1Context())
            {

                int affectedRows = 0;
                var product = db.Products;

                var sql = $"INSERT INTO [Shoppin Cart] (CustomerId,ProductId)VALUES ({1},{addtocart1})";

                using (var connection = new SqlConnection(connString))
                {
                    try
                    {
                        affectedRows = connection.Execute(sql);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine($"Product added to your cart {affectedRows}");
                }
                return affectedRows;

            }
        }

        // Metod för att söka efter en produkt
        public static void SearchAndShowProducts()
        {
            var search = Console.ReadLine();

            using (var db = new Models.HockeyShop1Context())
            {
                var products = db.Products;
                var productsWithShortName = from prod in products
                                            join b in db.Brands on prod.BrandId equals b.Id
                                            where
                                            prod.ModelName.Contains(search)
                                            orderby prod.ModelName
                                            select prod.Id + " " + " " +" " + b.BrandName + " "+ prod.ModelName.ToUpper() + " (" + prod.Price + " kr)";

                foreach (var prodList in productsWithShortName)
                {
                    Console.WriteLine(prodList);
                }

            }

        }
        // Betalning
        public static int Payment()
        {
            int affectedRows = 0;
            var sql = $"DELETE FROM [Shoppin Cart] WHERE Id between 1 and 100";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Thanks you shopping with us. Welcome again!");
            }
            return affectedRows;
        }
      
      
        // tar bort produkt från varukorgen
        public static int RemoveProductFromCart(int removeFromCart)
        {
            
                int affectedRows = 0;
                var sql = $"DELETE FROM [Shoppin Cart] WHERE Id = {removeFromCart}";

                using (var connection = new SqlConnection(connString))
                {
                    try
                    {
                        affectedRows = connection.Execute(sql);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine($"Product removed from your cart {affectedRows}");
                }
                return affectedRows;

        }
        // Admin metoder
        public static int ChangeProductModelName(string newNameOn, int Id)
        {
            int affectedRows = 0;
            var sql = $"Update Products SET ModelName = ('{newNameOn}') WHERE Id = ('{Id}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Modelname updated ");
            }
            return affectedRows;

        }



        public static int  ChangeProductPrice(float newPrice, int Id)
        {
            int affectedRows = 0;

            var sql = $"Update Products SET Price = ('{newPrice}') WHERE Id = ('{Id}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Price updated ");
            }
            return affectedRows;
        }

        public static int ChangeProductDescription(int ID, string desp)
        {

            
                int affectedRows = 0;
                var sql = $"Update Products SET Description = ('{desp}') WHERE Id = ('{ID}')";

                using (var connection = new SqlConnection(connString))
                {
                    try
                    {
                        affectedRows = connection.Execute(sql);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine($"Description updated ");
                }
                return affectedRows;


        }

        public static int ChangeProductCategory(int newId, int productId)
        {
            int affectedRows = 0;
            var sql = $"Update Products SET CategoryId = ('{newId}') WHERE Id = ('{productId}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Category updated ");
            }
            return affectedRows;


        }


    }
}
