using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace BangazonOrientation.Services
{
    public class CustomersRepository
    {

        public List<CustomersDto> ListAllCustomers()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getCustomerList = db.Execute(@"SELECT * FROM FirstName +' '+ LastName as FullName, PhoneNumber");

                return getCustomerList;
            }
        }
        
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

    }
}