namespace ECommerceAPI.Models.Products
{
    public class Product_Create
    {
        public string? Title { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public double Quantity { get; set; }
        public double Rating { get; set; }
    }
}