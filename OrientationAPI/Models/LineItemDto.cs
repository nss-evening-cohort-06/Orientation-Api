using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Models
{
    public class LineItemDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}