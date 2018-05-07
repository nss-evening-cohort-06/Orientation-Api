using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.Models;
using BangazonOrientation.Services;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/computers")]
    public class ComputersController : ApiController
    {
        [Route(""), HttpGet]
        public HttpResponseMessage Get()
        {
            var repo = new ComputersRepository();
            var results = repo.Get();

            return results == null 
                ? Request.CreateErrorResponse(HttpStatusCode.NoContent, "No computer records exist") 
                : Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("available"), HttpGet]
        public HttpResponseMessage GetAvailableComputers()
        {
            var repo = new ComputersRepository();
            var results = repo.GetAvailableComputers();

            return results == null
                ? Request.CreateErrorResponse(HttpStatusCode.NoContent, "No available computers")
                : Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("{id}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var repo = new ComputersRepository();
            var result = repo.GetById(id);

            return result == null
                ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "A computer with that id does not extis")
                : Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route(""), HttpPost]
        public HttpResponseMessage Get(ComputersDto computer)
        {
            var repo = new ComputersRepository();
            var result = repo.Post(computer);

            return result
                ? Request.CreateResponse(HttpStatusCode.Created)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to Process your request");
        }

        [Route("{id}"), HttpPut]
        public HttpResponseMessage Put(ComputersDto computer, int id)
        {
            var repo = new ComputersRepository();
            computer.ComputerID = id;
            var result = repo.Put(computer);

            return result
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to Process your request");
        }

        [Route("{id}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var repo = new ComputersRepository();
            var result = repo.Delete(id);

            return result
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No computer exists with that id");
        }
    }
}
