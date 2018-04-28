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
                                                       ,[DepartmentID])
                                                    VALUES
                                                        (@FirstName,
                                                         @LastName,
                                                         @StartDate,
                                                         @DepartmentID)", employee);

                return addEmployee == 1;
            }
        }

        public EmployeesDto GetEmployeeById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<EmployeesDto>(@"SELECT [EmployeeID]
                                                                          ,[FirstName]
                                                                          ,[LastName]
                                                                          ,[DepartmentID]
                                                                          ,[StartDate]
                                                                      FROM [dbo].[Employee]
                                                                      WHERE EmployeeID = @id", new {id});

                return result;
            }
        }

        public bool Edit(EmployeesDto employee, int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Employee]
                                             SET [FirstName] = @firstName
                                                ,[LastName] = @lastName
                                                ,[DepartmentID] = @departmentID
                                                ,[StartDate] = @startDate
                                          WHERE employeeID = @employeeID", new {employee, id});

                return result == 1;
            }
        }

    }
}