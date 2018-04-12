using OrientationAPI.Models;
using OrientationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationAPI.Controllers
{
	[RoutePrefix("api/customers")]
	public class CustomerController : ApiController
    {
		[Route(""), HttpPost]
		public HttpResponseMessage AddCustomer(CustomerDto customer)
		{
			var repository = new CustomerRepository();
			var result = repository.Create(customer);

			if (result)
			{
				return Request.CreateResponse(HttpStatusCode.Created);
			}
			return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer could not be created, please try again later.");
		}
	        [HttpGet, Route("")]
        public HttpResponseMessage ListCustomers()
        {
            var repo = new CustomerRepository();
            var dbResults = repo.GetAll();
            return Request.CreateListRecordsResponse(dbResults);
        }
        		[Route("{customerId}"), HttpPatch]
		public HttpResponseMessage UpdateCustomer(Customer customer, int customerId)
		{
			customer.CustomerId = customerId;
			var repository = new CustomerRepository();
			var result = repository.Update(customer);

			if (result)
			{
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update customer information, please try again later.");

		}


        [HttpPatch, Route("{customerId}/deactivate")]
        public HttpResponseMessage DeactivateCustomer(int customerId)
        {
            var repo = new CustomerRepository();
            var dbResults = repo.Deactivate(customerId);
            return Request.CreateUpdateRecordResponse(dbResults);
        }
		
    }
}
