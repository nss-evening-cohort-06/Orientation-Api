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
        [Route("{id}"), HttpPut]
        public HttpResponseMessage Put(CustomersDto customer)
        {
            var repository = new CustomersRepository();
            var result = repository.Edit(customer);

            return (result)
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update customer. Please try again.");
        }
        
        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            var repository = new CustomersRepository();
            var result = repository.ListAllCustomers();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    
        [Route("{customerId}/status"), HttpPut]
        public HttpResponseMessage UpdateCustomer(int customerId, CustomersDto customer)
        {
            var repository = new CustomersRepository();
            var StatusResult = repository.UpdateCustomerStatus(customer.Status, customerId);

            if (StatusResult)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update");
        }

        [Route, HttpPost]
        public HttpResponseMessage AddCustomer(CustomersDto customer)
        {
            var repo = new CustomersRepository();
            var result = repo.Create(customer);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create recipe, try again later...");
        }
    }
}
