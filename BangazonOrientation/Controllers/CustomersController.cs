using BangazonOrientation.Models;
using BangazonOrientation.Services;
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
    }
}
