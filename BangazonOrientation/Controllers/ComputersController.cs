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

        [Route("{id}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var repo = new ComputersRepository();
            var result = repo.GetById(id);

            return result == null
                ? Request.CreateErrorResponse(HttpStatusCode.NoContent, "A computer with that id does not extis")
                : Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //[Route(""), HttpPost]
        //public HttpResponseMessage Get(ComputersDto computer)
        //{

        //}

        //[Route("{id}"), HttpPut]
        //public HttpResponseMessage Put(ComputersDto computer)
        //{

        //}

        //[Route("{id}"), HttpDelete]
        //public HttpResponseMessage Delete(int id)
        //{

        //}
    }
}
