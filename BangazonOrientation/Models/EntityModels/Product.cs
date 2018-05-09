namespace BangazonOrientation.Models.EntityModels
{
    public class Product
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Price { get; set; }
        public virtual string Owner { get; set; }
        public virtual string Count { get; set; }
        public virtual string Description { get; set; }
        public virtual bool OutOfStock { get; set; }
    }
}