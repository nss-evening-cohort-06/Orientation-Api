﻿using BangazonOrientation.Models;
using BangazonOrientation.Services;
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

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetEmployee(int id)
        {
            var repository = new EmployeesRepository();
            var result = repository.GetEmployeeById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpPut]
        public HttpResponseMessage Edit(EmployeesDto employee, int id)
        {
            var repository = new EmployeesRepository();
            var result = repository.Edit(employee, id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{id}/computer"), HttpGet]
        public HttpResponseMessage GetEmployeeComputer(int id)
        {
            var repo = new EmployeesRepository();
            var result = repo.GetEmployeeComputer(id);

            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return GetEmployee(id);
        }

        [Route("training"), HttpGet]
        public HttpResponseMessage GetAllTraining()
        {
            var repo = new EmployeesRepository();
            var result = repo.GetAllTraining();

            return Request.CreateResponse(HttpStatusCode.OK, result);
            
        }

        [Route("training/{id}"), HttpGet]
        public HttpResponseMessage GetAllTrainingByEmployeedId(int id)
        {
            var repo = new EmployeesRepository();
            var result = repo.GetAllTrainingByEmployeeId(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
    }
}
