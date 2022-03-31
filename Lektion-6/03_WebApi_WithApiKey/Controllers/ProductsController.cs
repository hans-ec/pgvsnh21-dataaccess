using _03_WebApi_WithApiKey.Services;
using Forms = _03_WebApi_WithApiKey.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _03_WebApi_WithApiKey.Filters;

namespace _03_WebApi_WithApiKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }


        
        [HttpPost]
        [UseAdminApiKey]
        public async Task<IActionResult> CreateAsync(Forms.Product product)
        {
            return await _productManager.CreateProductAsync(product);
        }


        [HttpGet]      
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _productManager.GetAllProductsAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new OkObjectResult(await _productManager.GetAsync(id));
        }
    }
}
