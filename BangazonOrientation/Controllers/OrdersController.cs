using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.Models;
using BangazonOrientation.Services;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddOrder(OrdersDto order)
        {
            var repo = new OrdersRepository();
            var result = repo.Create(order);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create order, try again later...");
        }

        [Route("{OrderID}/{CustomerID}"), HttpPut]
        public HttpResponseMessage PlaceOrder(int OrderID, int CustomerID)
        {
            var repository = new OrdersRepository();
            var StatusResult = repository.UpdatePurchasedStatus(OrderID, CustomerID);

            if (StatusResult)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update.  CustomerID and/or OrderID not found.");
        }


    }
}