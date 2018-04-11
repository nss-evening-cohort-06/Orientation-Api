using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BangazonOrientation.Models;
using Dapper;

namespace BangazonOrientation.Services
{
    public class ProductsRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        public bool Create(ProductsDto product)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var lines = db.Execute(@"INSERT INTO [dbo].[Product]
                                               ([Name]
                                               ,[Price]
                                               ,[Owner]
                                               ,[Count]
                                               ,[Description])
                                         VALUES
                                               (@Name
                                               ,@Price
                                               ,@Owner
                                               ,@Count
                                               ,@Description)", product);

                return lines == 1;
            }
        }

        public IEnumerable<ProductsDto> ListAllProducts()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getProductList = db.Query<ProductsDto>(@"SELECT  Name, Price FROM Product");

                return getProductList;
            }
        }

    }
}