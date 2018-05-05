using System;

namespace BangazonOrientation.Models
{
    public class EmployeesDto
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}