using System;

namespace BangazonOrientation.Models.EntityModels
{
    public class Training
    {
        public virtual int Id { get; set; }
        public virtual string TrainingTitle { get; set; }
        public virtual DateTime StartDate { get; set; }
    }
}