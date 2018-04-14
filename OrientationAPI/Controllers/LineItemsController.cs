using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationAPI.Models;
using OrientationAPI.Services;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/lineitems")]
    public class LineItemsController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage AddLineItem(LineItemDto lineItem)
        {
            var counter = new ProductQuantity();
            var productAvailable = counter.ProductIsAvailable(lineItem.ProductId);
            if (!productAvailable)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "That product is out of stock and cannot be added to your order at this time");
            }

            var repo = new LineItemRepository();
            var dbResult = repo.Create(lineItem);

            return Request.CreateAddRecordResponse(dbResult);
        }
    }
}
