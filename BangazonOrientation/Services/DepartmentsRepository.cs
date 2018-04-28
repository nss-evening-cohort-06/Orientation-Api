using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BangazonOrientation.Models;

namespace BangazonOrientation.Services
{
    public class DepartmentsRepository
    {
        public IEnumerable<DepartmentsDto> ListAllDepartments()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getDepartmentList = db.Query<DepartmentsDto>(@"SELECT DepartmentID, Name, Budget FROM Department");

                return getDepartmentList;
            }
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        public bool Create(DepartmentsDto department)
        {
           using (var db = GetConnection())
            {
                db.Open();
                var records = db.Execute(@"INSERT INTO [dbo].[Department]
                                                     ([DepartmentID]
                                                     ,[Name]
                                                     ,[Budget])
                                                VALUES
                                                     (@DepartmentID
                                                     ,@Name
                                                     ,@Budget)", department);
                return records == 1;
            }
        }

        public IEnumerable<EmployeesDto> ListDepartmentEmployees(int DepartmentID)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getDepartmentEmployees = db.Query<EmployeesDto>(@"SELECT FirstName, LastName, EmployeeID 
                                                                          FROM Employee 
                                                                          join Department
                                                                            on Department.DepartmentID = Employee.DepartmentID
                                                                         WHERE Department.DepartmentID = @DepartmentID", new { DepartmentID });
                return getDepartmentEmployees;
            }
        } 

    }
}