using Dapper;
using ECommerceAPI.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ApiController : ControllerBase
    {
         private readonly IConfiguration _config;
         private readonly IProduct _product;
        public ApiController(IConfiguration config, IProduct product)
        {
            _config = config;
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts()
        {
            try {
                var products = await Task.FromResult(_product.GetProducts());
                return Ok(products);
            } catch (Npgsql.PostgresException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try {
                var product = await Task.FromResult(_product.GetProductById(id));
                return Ok(product);
            } catch (Npgsql.PostgresException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] Product product)
        {
            try {

                var userParams = new DynamicParameters();
                userParams.Add("id", product.Id);
                userParams.Add("title", product.Title);
                userParams.Add("description", product.Description);
                userParams.Add("price", product.Price);
                userParams.Add("quantity", product.Quantity);
                userParams.Add("rating", product.Rating);
                userParams.Add("category", product.Category);

                var result = await Task.FromResult(_product.CreateProduct(userParams));  
                return Ok(result);
            } catch (Npgsql.PostgresException e) {
                return BadRequest(e.Message);
            }
        }
    }
}