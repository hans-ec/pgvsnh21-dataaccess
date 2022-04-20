using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public ProductsController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            var item = await _dataAccess.CreateProductAsync(request);
            if (item != null)
                return new OkObjectResult(item);

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _dataAccess.GetAllProductsAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _dataAccess.GetProductAsync(id);
            if (item != null)
                return new OkObjectResult(item);

            return new NotFoundResult();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductRequest request)
        {
            var item = await _dataAccess.UpdateProductAsync(id, request);
            if (item != null)
                return new OkObjectResult(item);

            return new BadRequestResult();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dataAccess.DeleteProductAsync(id))
                return new OkResult();

            return new BadRequestResult();
        }
    }
}
