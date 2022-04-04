using _01_WebApi_Authentication.Models.Data;
using _01_WebApi_Authentication.Models.Entities;
using _01_WebApi_Authentication.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _01_WebApi_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            try
            {
                if (await _context.Users.AnyAsync(x => x.Email == form.Email))
                    return new ConflictObjectResult("A user with the same email already exists");

                var userEntity = new UserEntity
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email
                };
                userEntity.CreateSecurePassword(form.Password);
                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult("User created successfully");
            }
            catch
            {
                return new BadRequestResult();
            }
        }





        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (string.IsNullOrEmpty(form.Email) || string.IsNullOrEmpty(form.Password))
                return new BadRequestObjectResult("Email and password must be provided");

            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == form.Email);
            if (userEntity == null)
                return new BadRequestObjectResult("Incorrect email or password");

            if (!userEntity.CompareSecurePassword(form.Password))
                return new BadRequestObjectResult("Incorrect email or password");


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEntity.Email),
                    new Claim(ClaimTypes.Email, userEntity.Email),
                    new Claim("UserId", userEntity.Id.ToString()),
                    new Claim("ApiKey", _configuration.GetValue<string>("ApiKey"))
                }),

                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"))),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return new OkObjectResult(accessToken);
        }

    }
}
