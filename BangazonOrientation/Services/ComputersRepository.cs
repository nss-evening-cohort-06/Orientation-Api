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
    public class ComputersRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        public List<ComputersDto> Get()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var results = db.Query<ComputersDto>(@"select * from computer");

                return results.ToList();
            }
        }

        public ComputersDto GetById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<ComputersDto>(@"select * from computer where computerID = @id", new {id});

                return result;
            }
        }

        public bool Post(ComputersDto computer)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Execute(@"INSERT INTO [dbo].[Computer]
                                                       ([Manufacturer]
                                                       ,[Make]
                                                       ,[PurchaseDate])
                                                 VALUES
                                                       (@manufacturer
                                                       ,@make
                                                       ,@purchaseDate)", computer);
                return result == 1;
            }
            

        }
    }
}