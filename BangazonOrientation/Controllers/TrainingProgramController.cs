﻿using BangazonOrientation.Models;
using BangazonOrientation.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/trainingprogram")]
    public class TrainingProgramController : ApiController
    {

        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            var repo = new TrainingProgramRepository();
            var result = repo.GetAllTrainingPrograms();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{id}/edit"), HttpPut]
        public HttpResponseMessage EditTrainingProgram(int id, TrainingProgramDto training)
        {
            var repo = new TrainingProgramRepository();
            var StatusResult = repo.Edit(id, training);

            if (StatusResult)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update");
        }

        [Route("create"), HttpPost]
        public HttpResponseMessage AddTrainingProgram(TrainingProgramDto training)
        {
            var repo = new TrainingProgramRepository();
            var result = repo.Create(training);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create training program, try again later...");
        }

        [Route("{id}/employeelist"), HttpGet]
        public HttpResponseMessage GetEmployeeTrainingList(int id)
        {
            var repo = new TrainingProgramRepository();
            var result = repo.GetEmployeeTrainingList(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}