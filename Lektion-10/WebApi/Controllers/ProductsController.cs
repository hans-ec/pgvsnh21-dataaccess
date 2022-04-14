using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Product;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.CreateAsync(product);
            if (result != null)
                return new OkObjectResult(result);

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _service.GetAll());
        }

        [HttpDelete("{artnr}")]
        public async Task<IActionResult> Delete(string artnr)
        {
            if (await _service.DeleteAsync(artnr))
                return new OkResult();

            return new NotFoundResult();
        }
    }
}
