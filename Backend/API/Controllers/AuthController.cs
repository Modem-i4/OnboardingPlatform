using BusinessLogic.Dto.Auth;
using BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("registration")]
        public async Task<ActionResult<RegistrationDto>> Registration([FromBody] RegistrationDto user)
        {
            var createdUser = await authService.Registration(user);

            if (!createdUser.Succeeded)
            {
                return BadRequest(createdUser.Errors);
            }

            return Ok("Congratulations, you are successfully registered on.");
        }
    }
}
