﻿using System.Configuration;
using System.Data.SqlClient;
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

        public bool UpdatePurchasedStatus(int OrderID, int CustomerID)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString))
            {
                db.Open();
                var orderUpdated = db.Execute(@"UPDATE [dbo].[Order]
                                                            SET[Purchased] = 1
                                                            WHERE OrderID = @OrderID
                                                            AND CustomerID = @CustomerID", new { OrderID, CustomerID });

                return orderUpdated == 1;
            }
        }
    }
}