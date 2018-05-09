using System;

namespace BangazonOrientation.Models.EntityModels
{
    public class TrainingProgram
    {
        public virtual int Id { get; set; }
        public virtual int? MaxAttendees { get; set; }
        public virtual string TrainingTitle { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}