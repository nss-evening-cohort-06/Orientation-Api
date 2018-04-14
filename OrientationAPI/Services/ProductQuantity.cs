using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public class ProductQuantity
    {
        public bool ProductIsAvailable(int productId)
        {
            var repo = new ProductRepository();
            var product = repo.SelectProduct(productId);
            if (product.Quantity <= 0)
                return false;

            Subtract1FromQuantity(productId);
            return true;
        }

        public bool Subtract1FromQuantity(int productId)
        {
            var repo = new ProductRepository();
            var adjustProductQuantity = repo.Subtract1FromQuantity(productId);
            return true;
        }
    }
}