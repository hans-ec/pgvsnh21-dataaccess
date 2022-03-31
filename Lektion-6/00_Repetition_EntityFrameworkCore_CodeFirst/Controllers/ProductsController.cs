using _00_Repetition_EntityFrameworkCore_CodeFirst.Models;
using Forms = _00_Repetition_EntityFrameworkCore_CodeFirst.Models.Forms;
using _00_Repetition_EntityFrameworkCore_CodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _00_Repetition_EntityFrameworkCore_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }



        [HttpPost]
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
