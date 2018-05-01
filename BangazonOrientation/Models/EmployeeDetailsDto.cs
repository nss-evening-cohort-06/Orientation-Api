using System;
using System.Collections.Generic;

namespace BangazonOrientation.Services
{
    public class EmployeeDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public int DepartmentID { get; set; }
        public int ComputerID { get; set; }
        public string Manufacturer { get; set; }
        public string Make { get; set; }
        public string TrainingTitle { get; set; }
        public DateTime TrainingStartDate { get; set; }
    }
}