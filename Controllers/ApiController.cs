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
            var products = await _product.GetProducts();
            return Ok(products);
        }
    }
}