﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using BangazonOrientation.Models;
using Dapper;

namespace BangazonOrientation.Services
{
    public class CustomersRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        public bool Create(CustomersDto customer)
        {
            using (var db = GetConnection())
            {
                db.Open();
                customer.LastActiveDate = DateTime.Now;
                var records = db.Execute(@"INSERT INTO [dbo].[Customer]
                                                       ([FirstName]
                                                       ,[LastName]
                                                       ,[LastActiveDate]
                                                       ,[StreetAddress]
                                                       ,[City]
                                                       ,[State]
                                                       ,[ZipCode]
                                                       ,[PhoneNumber])
                                                 VALUES
                                                       (@FirstName
                                                       ,@LastName
                                                       ,@LastActiveDate
                                                       ,@StreetAddress
                                                       ,@City
                                                       ,@State
                                                       ,@ZipCode
                                                       ,@PhoneNumber)", customer);
                return records == 1;
            }
        }
    }
}