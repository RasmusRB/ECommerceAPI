namespace ECommerceAPI.Models.Cart
{
    public class Cart
    {
        public Guid Id { get; private set; }
        public string? UserId { get; private set; }
        public DateTime Date { get; private set; }
    }
}