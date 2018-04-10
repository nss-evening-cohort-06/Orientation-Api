using BangazonOrientation.Models;
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
        [Route("{customerId}/status"), HttpPut]
        public HttpResponseMessage UpdateCustomer (int customerId, CustomersDto customer)
        {
            var repository = new CustomersRepository();
            var StatusResult = repository.UpdateCustomerStatus(customer.Status, customerId);

            if (StatusResult)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update");
        }

    }
}
