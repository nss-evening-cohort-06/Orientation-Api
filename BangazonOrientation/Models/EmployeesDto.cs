﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonOrientation.Models
{
    public class EmployeesDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public int DepartmentID { get; set; }


    }
}