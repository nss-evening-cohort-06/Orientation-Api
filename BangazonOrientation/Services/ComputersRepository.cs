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
                var results = db.Query<ComputersDto>(@"select * from computers");

                return results.ToList();
            }
        }
    }
}