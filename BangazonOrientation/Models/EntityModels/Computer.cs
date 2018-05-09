using System;

namespace BangazonOrientation.Models.EntityModels
{
    public class Computer
    {
        public virtual int Id { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual string Make { get; set; }
        public virtual DateTime? PurchaseDate { get; set; }
    }
}