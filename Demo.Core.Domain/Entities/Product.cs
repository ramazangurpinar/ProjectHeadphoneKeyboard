namespace Demo.Core.Domain.Entities
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageFileName { get; set; }
        public bool Wireless { get; set; }
        public string Weight { get; set; }
        public string ProductType { get; set; }
    }
}
