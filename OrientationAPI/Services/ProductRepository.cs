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
    }
}