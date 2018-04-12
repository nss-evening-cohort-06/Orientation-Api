using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace OrientationAPI.Services
{
    public static class HttpResponseService
    {
        private static HttpResponseMessage MapHttpResponse(this HttpRequestMessage message, DbResponseEnum dbResponse)
        {
            switch (dbResponse)
            {
                case DbResponseEnum.Created:
                    return message.CreateResponse(HttpStatusCode.Created);
                case DbResponseEnum.NotCreated:
                    return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "The requested record could not be created, try again later");
                case DbResponseEnum.NoRecordsFound:
                    return message.CreateErrorResponse(HttpStatusCode.NotFound, "The record could not be found");
                case DbResponseEnum.Updated:
                    return message.CreateResponse(HttpStatusCode.OK);
                default:
                    return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not sure how we got here");
            }
              
        }

        private static HttpResponseMessage MapHttpResponse(this HttpRequestMessage message, DbResponseEnum dbResponse, IEnumerable<Customer> customers)
        {
            switch (dbResponse)
            {
                case DbResponseEnum.RecordsReturned:
                    return message.CreateResponse(HttpStatusCode.OK, customers);
                case DbResponseEnum.NoRecordsFound:
                    return message.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
                default:
                    return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not sure how we got here");
            }

        }

        public static HttpResponseMessage CreateAddRecordResponse(this HttpRequestMessage message, int dbResult)
        {
            return dbResult == 1 ? message.MapHttpResponse(DbResponseEnum.NoRecordsFound) : message.MapHttpResponse(DbResponseEnum.NotCreated);
        }

        public static HttpResponseMessage CreateUpdateRecordResponse(this HttpRequestMessage message, int dbResult)
        {
            return dbResult == 1 ? message.MapHttpResponse(DbResponseEnum.Created) : message.MapHttpResponse(DbResponseEnum.NotCreated);
        }

        public static HttpResponseMessage CreateListRecordsResponse(this HttpRequestMessage message, IEnumerable<Customer> dbResult)
        {
            return dbResult.Count() >= 1 ? message.MapHttpResponse(DbResponseEnum.RecordsReturned, dbResult) : message.MapHttpResponse(DbResponseEnum.NoRecordsFound);
        }

    }
}