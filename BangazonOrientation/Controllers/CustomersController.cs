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
        public HttpResponseMessage UpdateCustomer (CustomersDto customer)
        {
            var repository = new CustomerRepository();
            var result = repository.Update(customer);

            return 
        }

    }
}
