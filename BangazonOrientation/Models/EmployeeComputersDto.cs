using System;

namespace BangazonOrientation.Services
{
    public class EmployeeComputersDto
    {
        public int Id { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public int EmployeeID { get; set; }
        public int ComputerID { get; set; }
    }
}