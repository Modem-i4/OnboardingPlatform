using BusinessLogic.Dto.Auth;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ILoggerService loggerService;

        public AuthController(IAuthService authService, ILoggerService loggerService)
        {
            this.authService = authService;
            this.loggerService = loggerService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginDto loginViewModel)
        {
            var response = await authService.Login(loginViewModel);

            if (response == null)
            {
                loggerService.LogError("Invalid username or password");
                return BadRequest("Invalid username or password");
            }

            loggerService.LogInfo($"User: {response.UserId} succesfuly logged in");
            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<RegistrationDto>> Registration([FromBody] RegistrationDto user)
        {
            var createdUser = await authService.Registration(user);

            if (!createdUser.Succeeded)
            {
                loggerService.LogError("Something went wrong");
                return BadRequest(createdUser.Errors);
            }

            loggerService.LogInfo($"Created new user!");
            return Ok("Congratulations, you are successfully registered on.");
        }

        [HttpGet("verifyEmail")]
        public async Task<ActionResult<IdentityResult>> VerifyEmail(string userId, string token)
        {
            var response = await authService.VerifyEmail(userId, token);

            if (!response.Succeeded)
            {
                loggerService.LogError("Something went wrong");
                return BadRequest(response.Errors);
            }
            return Ok(response);
        }
    }
}
