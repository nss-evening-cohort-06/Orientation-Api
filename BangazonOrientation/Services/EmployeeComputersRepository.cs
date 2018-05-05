using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace BangazonOrientation.Services
{
    public class EmployeeComputersRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BangazonOrientation"].ConnectionString);
        }

        public EmployeeDetailsDto GetByComputerId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<EmployeeDetailsDto>(@"select * from EmployeeComputer where computerID = @id", new { id });

                return result;
            }
        }
        public EmployeeDetailsDto GetByEmployeeId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<EmployeeDetailsDto>(@"select * from EmployeeComputer where employeeID = @id", new { id });

                return result;
            }
        }
    }
}