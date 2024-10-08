using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Api
{

[Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_manager.ProductService.GetAllProducts(false));
        }
    }
}