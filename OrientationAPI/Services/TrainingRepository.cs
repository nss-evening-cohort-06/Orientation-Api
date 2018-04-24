using Dapper;
using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public class TrainingRepository
    {
        private SqlConnection getDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }
        public int Create(TrainingDto dto)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = @"INSERT INTO dbo.TrainingProgram
                            (name, description, startDate, endDate, maxAttendees)
                            VALUES 
                            (@name, @description, @startDate, @endDate, @maxAttendees)";
                return db.Execute(sql, dto);
            }
        }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }

        public List<TrainingList> GetAllActive()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString))
            {
                db.Open();
                var sql = "Select * From dbo.TrainingProgram";
                return db.Query<TrainingList>(sql).ToList();
            }
        }
    }

    public class TrainingList
    {
    }
}