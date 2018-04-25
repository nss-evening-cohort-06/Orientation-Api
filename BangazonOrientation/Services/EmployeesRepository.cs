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
                var getEmployeeList = db.Query<EmployeesDto>(@"SELECT EmployeeID, FirstName, LastName, StartDate FROM Employee");

                return getEmployeeList;
            }
        }
        
        public bool Create(EmployeesDto employee)
        {
            using (var db = GetConnection())
            {


                db.Open();
                var addEmployee = db.Execute(@"INSERT INTO [dbo].[Employee]
                                                       ([FirstName]
                                                       ,[LastName]
                                                       ,[StartDate]
                                                       ,[Department])
                                                    VALUES
                                                        (@FirstName,
                                                         @LastName,
                                                         @StartDate,
                                                         @Department)", employee);

                return addEmployee == 1;
            }
        }


    }
}