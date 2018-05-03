using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonOrientation.Models
{
    public class TrainingDto
    {
        public int TrainingProgramID { get; set; }
        public string TrainingTitle { get; set; }
        public DateTime StartDate { get; set; }
    }
}