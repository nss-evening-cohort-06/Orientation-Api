using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
    public class Order
    {
        public int OrderId {get; set;}
        public int CustomerId { get; set; }
        public DateTime? PaymentDate {get; set;}
        public DateTime CreatedDate {get; set;}
        public bool IsClosed {get; set;}
    }
}