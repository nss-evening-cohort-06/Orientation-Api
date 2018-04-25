using BangazonOrientation.Models;
using BangazonOrientation.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetDepartmentList()
        {
            var repository = new DepartmentsRepository();
            var result = repository.ListAllDepartments();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}