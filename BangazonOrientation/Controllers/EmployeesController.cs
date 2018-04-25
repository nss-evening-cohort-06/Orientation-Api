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
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            var repository = new EmployeesRepository();
            var result = repository.ListAllEmployees();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route, HttpPost]
        public HttpResponseMessage AddEmployee(EmployeesDto employee)
        {
            var repository = new EmployeesRepository();
            var result = repository.Create(employee);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "no!");
        }
    }
}
