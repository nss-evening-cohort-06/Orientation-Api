using System;

namespace BangazonOrientation.Models.EntityModels
{
    public class EmployeeDetail
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual int? DepartmentID { get; set; }
        public virtual int? ComputerID { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual string Make { get; set; }
        public virtual string TrainingTitle { get; set; }
        public virtual DateTime? TrainingStartDate { get; set; }
    }
}