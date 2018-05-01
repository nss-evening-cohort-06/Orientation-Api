using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public class OrderStatusChecker
    {
        public bool CheckIsClosed(int orderId)
        {
            var repo = new OrderRepository();
            var order = repo.SelectOrder(orderId);

            if (order.IsClosed)
            {
                return true;
            }

            return false;
        }
    }
}