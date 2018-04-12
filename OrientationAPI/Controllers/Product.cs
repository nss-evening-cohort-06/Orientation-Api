namespace OrientationAPI.Controllers
{
	public class Product
	{
		public int ProductId { get; set; }
		public int SellerId { get; set; }
		public string ProductName { get; set; }
		public double ProductPrice { get; set; }
		public int Quantity { get; set; }
	}
}