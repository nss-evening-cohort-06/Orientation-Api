using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BangazonOrientation.Services
{
    public class CustomersRepository
    {
        public bool UpdateCustomerStatus(bool Status, int CustomerId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString))
            {
                db.Open();

            }
        }
    }
}