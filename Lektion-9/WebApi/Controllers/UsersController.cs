using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.Forms;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    [UseAdminApiKey]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateForm form)
        {
            var user = await _userService.CreateAsync(form);
            if (user != null)
                return new OkObjectResult(user);

            return new BadRequestResult();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            return new OkObjectResult(await _userService.ReadAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.ReadAsync(id);
            if (user != null)
                return new OkObjectResult(user);

            return new NotFoundResult();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateForm form)
        {
            var user = await _userService.UpdateAsync(id, form);
            if (user != null)
                return new OkObjectResult(user);

            return new BadRequestResult();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {          
            if (await _userService.DeleteAsync(id))
                return new OkResult();

            return new BadRequestResult();
        }
    }
}
