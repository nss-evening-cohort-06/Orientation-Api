using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationAPI.Models;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController :
        ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage CreateOrder(OrderDto createOrder)
        {

        }

    }
}