using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.Models;
using BangazonOrientation.Services;

namespace BangazonOrientation.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddOrder(OrdersDto order)
        {
            var repo = new OrdersRepository();
            var result = repo.Create(order);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create order, try again later...");
        }

        [Route("{orderID}/paid"), HttpPut]
        public HttpResponseMessage UpDateOrder(int orderID)
        {
            var editPaymentStatus = new OrdersRepository();
            var result = editPaymentStatus.Purchase(orderID);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}