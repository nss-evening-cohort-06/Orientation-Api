using BangazonOrientation.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/EmployeeComputers")]
    public class EmployeeComputerController : ApiController
    {
        [Route("{id}"), HttpGet]
        public HttpResponseMessage GetByComputerId(int id)
        {
            var repo = new EmployeeComputersRepository();
            var result = repo.GetByComputerId(id);


            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not get computer by computer ID");
        }

        [Route("{id}/employee"), HttpGet]
        public HttpResponseMessage GetByEmployeeId(int id)
        {
            var repo = new EmployeeComputersRepository();
            var result = repo.GetByEmployeeId(id);

            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateResponse(HttpStatusCode.NoContent, result = null);
                }
    }
}