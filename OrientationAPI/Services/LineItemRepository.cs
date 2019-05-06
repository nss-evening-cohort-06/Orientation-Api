using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OrientationAPI.Models; 

namespace OrientationAPI.Services
{
    public class LineItemRepository
    {
        private SqlConnection getDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BRBangazon"].ConnectionString);
        }
        public int Create(LineItemDto lineItem)
        {
            using (var db = getDb())
            {
                db.Open();
                var sql = @"INSERT INTO dbo.LineItems
                            (orderId, productId)
                            VALUES 
                            (@orderId, @productId)";
                return db.Execute(sql, lineItem);
            }
        }
    }
}