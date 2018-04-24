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
    [RoutePrefix("api/training")]
    public class TrainingController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Create(TrainingDto dto)
        {
            var repo = new TrainingRepository();
            var dbResults = repo.Create(dto);
            return Request.CreateAddRecordResponse(dbResults);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            var repo = new TrainingRepository();
            var dbResults = repo.GetAll();
            return Request.CreateListRecordsResponse(dbResults);
        }
    }

}
