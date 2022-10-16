using Dapper;

namespace ECommerceAPI.Models.Products
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(DynamicParameters product);
    }
}