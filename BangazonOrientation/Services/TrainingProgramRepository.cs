using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BangazonOrientation.Models;

namespace BangazonOrientation.Services
{
    public class TrainingProgramRepository
    {
        // PUT support function
        public bool Edit(int id, TrainingProgramDto training)
        {
            training.TrainingProgramID = id;
            using (var db = GetConnection())
            {
                var numberEdited = db.Execute(@"UPDATE [dbo].[TrainingProgram]
                                   SET [MaxAttendees] = @MaxAttendees
                                      ,[TrainingTitle] = @TrainingTitle
                                      ,[Description] = @Description
                                      ,[StartDate] = @StartDate
                                      ,[EndDate] = @EndDate
                                       WHERE TrainingProgramID = @TrainingProgramID",  training );
                return numberEdited == 1;
            }
        }

        // POST support function
        public bool Create(TrainingProgramDto training)
        {
            using (var db = GetConnection())
            {
                db.Open();
               // training.StartDate = DateTime.Now;
                var records = db.Execute(@"INSERT INTO [dbo].[TrainingProgram]
                                                       ([MaxAttendees]
                                                       ,[TrainingTitle]
                                                       ,[Description]
                                                       ,[StartDate]
                                                       ,[EndDate])
                                                 VALUES
                                                       (@MaxAttendees
                                                       ,@TrainingTitle
                                                       ,@Description
                                                       ,@StartDate
                                                       ,@EndDate)", training);
                return records == 1;
            }
        }

        // GET support function for Training Programs
        public IEnumerable<TrainingProgramDto> GetAllTrainingPrograms()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getTrainingProgramList = db.Query<TrainingProgramDto>(@"SELECT * FROM TrainingProgram ORDER BY StartDate");

                return getTrainingProgramList;
            }
        }

        // GET support function to fetch Employees in Training Program
        public IEnumerable<EmployeesDto> GetEmployeeTrainingList(int trainingProgramId)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getEmployeeTrainingProgramList = db.Query<EmployeesDto>(
                                        @"SELECT
                                        E.FirstName, E.LastName 
	                                    FROM EmployeeTraining ET
	                                    JOIN Employee E ON ET.EmployeeID=E.EmployeeID
	                                    WHERE ET.TrainingProgramID = @trainingProgramId
	                                    ORDER BY E.LastName",new {trainingProgramId });

                return getEmployeeTrainingProgramList;
            }
        }

        // DELETE support function to delete a Training Program
        public bool Delete(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result1 = db.Execute(@"DELETE FROM EmployeeTraining WHERE TrainingProgramID = @id", new { id });
                var result2 = db.Execute(@"DELETE FROM TrainingProgram WHERE TrainingProgramID = @id", new { id });

                return (result1 + result2) >=1;
            }
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        
    }
}