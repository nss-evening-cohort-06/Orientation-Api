﻿using Dapper;
using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public class DepartmentRepository
    {
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }

        public IEnumerable<DepartmentDto> ListDepartment()
        {
            using (var db = GetDb())
            {
                db.Open();

                var getAllDepartments = db.Query<DepartmentDto>(@"select * from dbo.Departments");

                return getAllDepartments;
            }
        }

        public int AddNewDepartment(DepartmentDto department)
        {
            using (var db = GetDb())
            {
                db.Open();

                var newDepartmentQuery = @"INSERT INTO dbo.Departments
                            (name)
                            VALUES 
                            (@name)";
                return db.Execute(newDepartmentQuery, department);

            }
        }
    }
}