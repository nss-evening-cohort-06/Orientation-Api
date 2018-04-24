using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BangazonOrientation.Models;

namespace BangazonOrientation.Services
{
    public class CustomersRepository
    {
        public bool Edit(int id, CustomersDto customer)
        {
            customer.Id = id;
            customer.LastActiveDate = DateTime.Now;
            using (var db = GetConnection())
            {
                var numberEdited = db.Execute(@"UPDATE [dbo].[Customer]
                                   SET [FirstName] = @FirstName
                                      ,[LastName] = @LastName
                                      ,[LastActiveDate] = @LastActiveDate
                                      ,[StreetAddress] = @StreetAddress
                                      ,[City] = @City
                                      ,[State] = @State
                                      ,[ZipCode] = @ZipCode
                                      ,[PhoneNumber] = @PhoneNumber
                                        WHERE [CustomerID] = @Id", customer);
                return numberEdited == 1;
            }
        }

        public IEnumerable<CustomersDto> ListAllCustomers()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getCustomerList = db.Query<CustomersDto>(@"SELECT  FirstName, LastName, PhoneNumber FROM Customer");

                return getCustomerList;
            }
        }

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

        public bool UpdateCustomerStatus(bool Status, int CustomerId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString))
            {
                db.Open();
                var NumberOfCustomersUpdated = db.Execute(@"UPDATE [dbo].[Customer]
                                                            SET[Status] = @Status
                                                            WHERE CustomerId = @CustomerId", new { CustomerId, Status });

                return NumberOfCustomersUpdated == 1;
            }
        }
    }
}