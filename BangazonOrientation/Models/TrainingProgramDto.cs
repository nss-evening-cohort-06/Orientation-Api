using System;

namespace BangazonOrientation.Models
{
    public class TrainingProgramDto
    {
        public int TrainingProgramID { get; set; }
        public int MaxAttendees  { get; set; }
        public string TrainingTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}