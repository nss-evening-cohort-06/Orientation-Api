namespace BangazonOrientation.Models
{
    public class OrdersDto
    {
        public int OrderID { get; set; }
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public bool Purchased { get; set; }
    }
}