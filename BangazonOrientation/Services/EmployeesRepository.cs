using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
                var getEmployeeList = db.Query<EmployeesDto>(@"SELECT Employee.EmployeeID
                                                                    , Employee.FirstName
                                                                    , Employee.LastName
                                                                    , Employee.StartDate
                                                                    , Department.DepartmentID
                                                                    , Department.Name AS DepartmentName
	                                                        FROM Employee
	                                                        JOIN Department on Employee.DepartmentID = Department.DepartmentID");

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

        public EmployeeDetailsDto GetEmployeeComputer(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<EmployeeDetailsDto>(@"SELECT Employee.FirstName
                                                                                    ,Employee.LastName 
                                                                                    ,Employee.EmployeeID
                                                                                    ,Employee.StartDate 
                                                                                    ,Employee.DepartmentID 
                                                                                    ,Computer.Manufacturer
                                                                                    ,Computer.Make
                                                                                    ,Computer.ComputerID
                                                                                    ,TrainingProgram.TrainingTitle
                                                                                    ,TrainingProgram.StartDate as TrainingStartDate
	                                                                        FROM dbo.EmployeeComputer
	                                                                        JOIN dbo.Computer on EmployeeComputer.ComputerID = Computer.ComputerID
	                                                                        JOIN dbo.Employee on EmployeeComputer.EmployeeID = Employee.EmployeeID
                                                                            JOIN dbo.EmployeeTraining on Employee.EmployeeID = EmployeeTraining.EmployeeID
                                                                            JOIN dbo.TrainingProgram on EmployeeTraining.TrainingProgramID = TrainingProgram.TrainingProgramID
                                                                            WHERE Employee.EmployeeID = @id",
                    new {id});
                return result;
            }
        }

        public bool Edit(EmployeesDto employee, int id)
        {
            using (var db = GetConnection())
            {
                employee.EmployeeID = id;
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Employee]
                                             SET [FirstName] = @firstName
                                                ,[LastName] = @lastName
                                                ,[DepartmentID] = @departmentID
                                                ,[StartDate] = @startDate
                                          WHERE employeeID = @employeeID", employee);

                return result == 1;
            }
        }

        public List<TrainingDto> GetAllTraining()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Query<TrainingDto>(@"SELECT* FROM[SNQHM_bangazoncli_db].[dbo].[TrainingProgram]");
                return result.ToList();
            }
        }
    }
}