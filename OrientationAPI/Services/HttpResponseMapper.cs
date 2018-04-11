using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace OrientationAPI.Services
{
    public static class HttpResponseMapper
    {
        public static HttpResponseMessage MapHttpResponse(this HttpRequestMessage message, DbResponseMapper dbResponse)
        {
            switch (dbResponse)
            {
                case DbResponseMapper.Created:
                    return message.CreateResponse(HttpStatusCode.Created);
                case DbResponseMapper.NotCreated:
                    return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "The requested record could not be created, try again later");
                case DbResponseMapper.Success:
                    return message.CreateResponse(HttpStatusCode.OK);
                case DbResponseMapper.NotFound:
                    return message.CreateErrorResponse(HttpStatusCode.NotFound, "The requested record could not be found");
                default:
                    return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not sure how we got here");
            }
              
        }
    }
}