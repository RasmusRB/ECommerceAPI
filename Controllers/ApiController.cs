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
        [Route("products")]
        public async Task<ActionResult<Product>> GetProducts()
        {
                var products = await _product.GetProducts();
                return Ok(products);
        }
          

        [HttpGet]
        [Route("products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
                var product = await _product.GetProductById(id);
                return Ok(product);
           
        }

        [HttpPost]
        [Route("products/create")]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] Product_Create cProduct)
        {
               var userParams = new DynamicParameters();
                userParams.Add("@title", cProduct.Title);
                userParams.Add("@price", cProduct.Price);
                userParams.Add("@description", cProduct.Description);
                userParams.Add("@category", cProduct.Category);
                userParams.Add("@quantity", cProduct.Quantity);
                userParams.Add("@rating", cProduct.Rating);

                var product = await _product.CreateProduct(userParams);
                return Ok(product.Id);
        }

        [HttpDelete]
        [Route("products/delete/{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var deleted = await _product.DeleteProduct(id);
            return Ok(deleted.Id);
        }
    }
}