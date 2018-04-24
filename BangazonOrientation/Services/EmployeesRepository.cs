using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BangazonOrientation.Models;

namespace BangazonOrientation.Services
{
    public class EmployeesRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        
        public IEnumerable<EmployeesDto> ListAllEmployees()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getEmployeeList = db.Query<EmployeesDto>(@"SELECT  FirstName, LastName, FROM Employee");

                return getEmployeeList;
            }
        }
        


    }
}