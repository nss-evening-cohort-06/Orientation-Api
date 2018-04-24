using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonOrientation.Models
{
    public class ComputersDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Make { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}