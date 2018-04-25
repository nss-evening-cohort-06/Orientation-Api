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

        [Route, HttpPost]
        public HttpResponseMessage AddNewDepartment(DepartmentsDto department)
        {
            var repository = new DepartmentsRepository();
            var result = repository.Create(department);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not add new department");

        }
    }
}