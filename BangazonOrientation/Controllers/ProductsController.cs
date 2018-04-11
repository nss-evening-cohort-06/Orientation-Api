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
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddProduct(ProductsDto product)
        {
            var repo = new ProductsRepository();
            var result = repo.Create(product);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create product, try again later...");
        }

        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            var repository = new ProductsRepository();
            var result = repository.ListAllProducts();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
