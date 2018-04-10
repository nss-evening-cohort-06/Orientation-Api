﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationAPI.Models;
using OrientationAPI.Services;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController :
        ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage CreateOrder(OrderDto createOrder)
        {
            var repository = new OrderRepository();
            var result = repository.Create(createOrder.CustomerId);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create order");
        }

    }
}