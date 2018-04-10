using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.Controllers
{
    public class CustomersController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            var repository = new CustomerRepository();
            var result = repository.ListAllCustomers();

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Oh Balls!");
        }

    }
}
