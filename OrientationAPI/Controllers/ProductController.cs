﻿using OrientationAPI.Models;
using OrientationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [Route(""), HttpPost]
        public HttpResponseMessage AddProduct(ProductDto product)
        {
            var repository = new ProductRepository();
            var result = repository.Create(product);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, 
                                               "Product could not be created. Please try again later.");
        }

        [HttpGet, Route("")]
        public HttpResponseMessage ListProduct()
        {
            var repository = new ProductRepository();
            var result = repository.GetAll();

            if (result.ToString().Length > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Product could not be found. Please try again later");
            
        }
    }
}