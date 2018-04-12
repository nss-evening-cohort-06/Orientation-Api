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
            var repo = new LineItemRepository();
            var dbResult = repo.Create(lineItem);
            return Request.CreateAddRecordResponse(dbResult);
        }
    }
}
