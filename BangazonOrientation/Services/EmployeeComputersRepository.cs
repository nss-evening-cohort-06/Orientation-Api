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

        public EmployeeComputersDto GetByComputerId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<EmployeeComputersDto>(@"select * from EmployeeComputer where computerID = @id", new { id });

                return result;
            }
        }
    }
}