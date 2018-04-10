using BangazonOrientation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            var repository = new CustomersRepository();
            var result = repository.ListAllCustomers();

           

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
