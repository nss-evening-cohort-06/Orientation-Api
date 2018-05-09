using System;

namespace BangazonOrientation.Models.EntityModels
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastActiveDate { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int ZipCode { get; set; }
        public virtual int PhoneNumber { get; set; }
        public virtual bool Status { get; set; }
    }
}