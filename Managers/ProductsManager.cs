using System.Data;
using Dapper;
using ECommerceAPI.Models.Products;
using Npgsql;

namespace ECommerceAPI.Managers
{
    public class ProductsManager : IProduct
    {
            private string? _connectionString;
            private string? GetAllQuery = @"SELECT * FROM products";
            private string? GetProductQuery = @"SELECT * FROM products WHERE id = @id";
            private string? CreateProductQuery = @"INSERT INTO products (id, title, price, description, category, quantity, rating) VALUES (@id, @title, @price, @description, @category, @quantity, @rating)";
            private string? DeleteProductQuery = @"DELETE FROM products WHERE id = @id";

            public ProductsManager(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Database") + $"Database={config.GetConnectionString("DatabaseName")}";
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var res = await db.QueryAsync<Product>(GetAllQuery);
            return res.AsList();
        }

        public async Task<Product> GetProductById(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var res = await db.QuerySingleOrDefaultAsync<Product>(GetProductQuery, new { id });
            return res;
        }

        public async Task<Product> CreateProduct(DynamicParameters product)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var res = await db.QueryAsync<Product>(CreateProductQuery);
            return res.FirstOrDefault();
        }
    }
}