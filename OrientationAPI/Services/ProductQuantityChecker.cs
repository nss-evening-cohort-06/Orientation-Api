using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public class ProductQuantityChecker
    {
        public static bool ProductIsAvailable(int productId)
        {
            var repo = new ProductRepository();
            var product = repo.SelectProduct(productId);
            if (product.Quantity <= 0)
                return true;
            return false;
        }
    }
}