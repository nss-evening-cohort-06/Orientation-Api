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

    }
}