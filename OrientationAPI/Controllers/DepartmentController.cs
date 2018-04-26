using OrientationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
    {
       [HttpGet, Route("")]
       public HttpResponseMessage ListDepartment()
        {
            var repository = new DepartmentRepository();
            var result = repository.GetAll();
            return Request.CreateListRecordsResponse(result);
        }
    }
}