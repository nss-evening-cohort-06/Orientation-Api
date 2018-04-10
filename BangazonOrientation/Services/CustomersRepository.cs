using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using BangazonOrientation.Models;

namespace BangazonOrientation.Services
{
    public class CustomersRepository
    {

        public IEnumerable<CustomersDto> ListAllCustomers()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getCustomerList = db.Query<CustomersDto>(@"SELECT  FirstName, LastName, PhoneNumber FROM Customer");

                return getCustomerList;
            }
        }
        
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

    }
}