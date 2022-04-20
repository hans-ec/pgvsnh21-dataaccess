using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public CustomersController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequest request)
        {
            var item = await _dataAccess.CreateCustomerAsync(request);
            if (item != null)
                return new OkObjectResult(item);

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _dataAccess.GetAllCustomersAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _dataAccess.GetCustomerAsync(id);
            if (item != null)
                return new OkObjectResult(item);

            return new NotFoundResult();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerRequest request)
        {
            var item = await _dataAccess.UpdateCustomerAsync(id, request);
            if (item != null)
                return new OkObjectResult(item);

            return new BadRequestResult();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dataAccess.DeleteCustomerAsync(id))
                return new OkResult();

            return new BadRequestResult();
        }
    }
}
