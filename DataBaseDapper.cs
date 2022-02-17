using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HockeyShop1.Models;
using Microsoft.Data.SqlClient;

namespace HockeyShop1
{
    class DataBaseDapper
    {

        static string connString = "data source=.\\SQLEXPRESS; initial catalog=HockeyShop1; persist security info=true; Integrated Security=true";
        //static string connString = "Server=tcp:newtondemo50.database.windows.net,1433;Initial Catalog=DemoDB;Persist Security Info=False;User ID=Admin50;Password=1992LunkaN;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=3000";

        

        public static int AddProductAdmin(Models.Product product)
        {
            int affectedRows = 0;
            var sql = $"INSERT INTO Products (CategoryId,BrandId,ModelName,Color,Price) VALUES ('{product.CategoryId}', '{product.BrandId}', '{product.ModelName}','{product.Color}','{product.Price}')";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine($"Product added");
            }
            return affectedRows;
        }
        public static int RemoveProductAdmin (int product1)
        {
                int affectedRows = 0;
                var sql = $"DELETE FROM Products WHERE Id = {product1}";

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
                    Console.WriteLine($"Product removed");
                }

                return affectedRows;
        }


    }
}
