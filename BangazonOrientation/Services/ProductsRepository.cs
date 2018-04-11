﻿using System.Configuration;
using System.Data.SqlClient;
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
    }
}