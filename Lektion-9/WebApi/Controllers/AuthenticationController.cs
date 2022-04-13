using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Forms;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _profileService;

        public AuthenticationController(IUserService userService, IUserProfileService profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            var user = await _userService.CreateAsync(new Models.Forms.UserCreateForm(form.FirstName, form.LastName, form.Email, form.Password));
            if (user != null)
            {
                var userProfile = await _profileService.CreateProfileAsync(new Models.UserProfileCreate(user.Id, form.AddressLine, form.ZipCode, form.City));
                if (userProfile != null)
                    return new OkResult();
            }
               
            return new BadRequestResult();
        }
    }
}
