using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonOrientation.Models
{
    public class ProductsDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Owner { get; set; }
        public string Count { get; set; }
        public string Description { get; set; }
    }
}