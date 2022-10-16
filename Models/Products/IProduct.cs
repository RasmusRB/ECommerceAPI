namespace ECommerceAPI.Models.Products
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}