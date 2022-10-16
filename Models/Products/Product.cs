namespace ECommerceAPI.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public double Quantity { get; set; }
        public double Rating { get; set; }
    }
}