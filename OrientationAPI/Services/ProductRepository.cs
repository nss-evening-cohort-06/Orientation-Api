﻿using Dapper;
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
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }

        public bool Create(ProductDto product)
        {
            using (var db = GetDb())
            {
                db.Open();
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

        public ProductDto SelectProduct(int productId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = @"SELECT * FROM [dbo].[Products]
                               WHERE ProductId = @productId";

                return db.QueryFirst<ProductDto>(result, new {productId});
            }
        }

        public bool Subtract1FromQuantity(int productId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Products]
                                          SET [Quantity] = Quantity -1
                                          WHERE ProductId = @productid", new {productId});
                return result == 1;
            }
        }
        
    }
}