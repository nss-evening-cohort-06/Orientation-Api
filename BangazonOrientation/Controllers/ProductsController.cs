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
    }
}
