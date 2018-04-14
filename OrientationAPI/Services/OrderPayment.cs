using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public static class OrderPayment
    {
        public static int PayForOrder(int orderId)
        {
            var repo = new OrderRepository();
            var order = repo.SelectOrder(orderId);

            if (!order.IsClosed || order.PaymentDate.HasValue) return -1;
            return repo.PayForOrder(orderId);
        }
    }
}