namespace BangazonOrientation.Models.EntityModels
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual int PaymentID { get; set; }
        public virtual int CustomerID { get; set; }
        public virtual bool Purchased { get; set; }
    }
}