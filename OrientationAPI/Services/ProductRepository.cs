﻿using Dapper;
using OrientationAPI.Controllers;
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

		public int Create(ProductDto product)
		{
			using (var db = GetDb())
			{
				db.Open();
				return db.Execute(@"INSERT INTO [dbo].[Products]
                                                   ([ProductName]
                                                   ,[ProductPrice]
                                                   ,[SellerId]
                                                   ,[Quantity])
                                             VALUES
                                                   (@ProductName
                                                   ,@ProductPrice
                                                   ,@SellerId
                                                   ,@Quantity)", product);
			}
		}

		public int RemoveProduct(Product product)
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				return db.Execute(@"UPDATE [dbo].[Products]
                                                  SET [ProductName] = @ProductName,
                                                      [ProductPrice] = @ProductPrice,
													  [SellerId] = @SellerId,
                                                      [Quantity] = 0
												 WHERE ProductId = @ProductId", product);
			}
		}

		public ProductDto SelectProduct(int productId)
		{
			using (var db = GetDb())
			{
				db.Open();
				var result = @"SELECT * FROM [dbo].[Products]
                               WHERE ProductId = @productId";

				return db.QueryFirst<ProductDto>(result, new { productId });
			}
		}

		public IEnumerable<Product> GetAll()
		{
			using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
			{
				db.Open();

				var getAllProducts = db.Query<Product>(@"select * from dbo.Products");

				return getAllProducts;
			}
		}

		public bool Subtract1FromQuantity(int productId)
		{
			using (var db = GetDb())
			{
				db.Open();
				var result = db.Execute(@"UPDATE [dbo].[Products]
                                          SET [Quantity] = Quantity -1
                                          WHERE ProductId = @productid", new { productId });
				return result == 1;
			}
		}
    }
}