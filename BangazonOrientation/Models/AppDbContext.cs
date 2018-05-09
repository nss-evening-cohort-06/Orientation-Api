using BangazonOrientation.Models.EntityModels;
using System.Data.Entity;

namespace BangazonOrientation.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("BangazonOrientationDbFromEntity") { }

        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }
    }
}