using System.Data;
using Dapper;
using ECommerceAPI.Models.Products;
using Npgsql;

namespace ECommerceAPI.Managers
{
    public class ProductsManager : IProduct
    {
            private string? _connectionString;
            private string? GetAll = @"SELECT * FROM products";

            public ProductsManager(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Database") + $"Database={config.GetConnectionString("DatabaseName")}";
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var res = await db.QueryAsync<Product>(GetAll);
            return res.AsList();
        }
    }
}