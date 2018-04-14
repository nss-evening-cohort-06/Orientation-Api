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
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [Route(""), HttpPost]
        public HttpResponseMessage AddProduct(ProductDto product)
        {
            var repository = new ProductRepository();
			var dbResults = repository.Create(product);
			return Request.CreateAddRecordResponse(dbResults);        
        }

		[Route("{productId}/removeProduct"), HttpPatch]
		public HttpResponseMessage RemoveProduct(Product product, int productId)
		{
			product.ProductId = productId;
			var repository = new ProductRepository();
			var dbResults = repository.RemoveProduct(product);
			return Request.CreateUpdateRecordResponse(dbResults);
		}
	}
}