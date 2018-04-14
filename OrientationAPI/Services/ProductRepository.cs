using Dapper;
using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public class ProductRepository
    {
        public bool Create(ProductDto product)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
            {
                var numberCreated = db.Execute(@"INSERT INTO [dbo].[Products]
                                                   ([ProductName]
                                                   ,[ProductPrice]
                                                   ,[SellerId]
                                                   ,[Quantity])
                                             VALUES
                                                   (@ProductName
                                                   ,@ProductPrice
                                                   ,@SellerId
                                                   ,@Quantity)", product);

                return numberCreated == 1;
            }
        }


























        public int GetQuantityInStock(int productId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
            {
                var sql = "SELECT Quantity FROM [dbo].[Products] WHERE ProductId = @ProductId";
                return db.QueryFirst<int>(sql, new { productId });
            }
        }

        

        public int DecrementQuanity(int productId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
            {
                var sql = "UPDATE [dbo].[Products] SET Quantity = Quantity - 1 WHERE ProductId = @productId";
                return db.Execute(sql, new { productId });

            }
        }
    }
}