using System;
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
    public class OrdersRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        public bool Create(OrdersDto order)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var records = db.Execute(@"INSERT INTO [dbo].[Order]
                                                       ([PaymentID]
                                                       ,[CustomerID]
                                                       ,[Purchased])
                                                 VALUES
                                                       (@PaymentID
                                                       ,@CustomerID
                                                       ,@Purchased)", order);
                return records == 1;
            }
        }
    }
}