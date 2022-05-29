using BusinessLogic.Dto.Auth;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataAccess.DataContext;

namespace API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly ILoggerService loggerService;

        public AuthController(IAuthService authService, ILoggerService loggerService)
        {
            this.authService = authService;
            this.loggerService = loggerService;
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<LoginViewModel>> Login(LoginDto loginViewModel)
        {
            if (loginViewModel == null) return View();

            var response = await authService.Login(loginViewModel);

            if (response == null)
            {
                loggerService.LogError("Invalid username or password");
                return BadRequest("Invalid username or password");
            }

            loggerService.LogInfo($"User: {response.UserId} succesfuly logged in");
            return Ok(response);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration([Bind("Email,Password,FirstName,LastName,Username")]  RegistrationDto user)
        {
            var createdUser = await authService.Registration(user);

            if (!createdUser.Succeeded)
            {
                loggerService.LogError("Something went wrong");
                return BadRequest(createdUser.Errors);
            }

            loggerService.LogInfo($"Created new user!");
            return RedirectToAction("SuccessfullyRegistered", "auth");
        }

        [HttpGet]
        public async Task<ActionResult<IdentityResult>> VerifyEmail(string userId, string token)
        {
            var response = await authService.VerifyEmail(userId, token);

            if (!response.Succeeded)
            {
                loggerService.LogError("Something went wrong");
                return BadRequest(response.Errors);
            }
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SuccessfullyRegistered()
        {
            return View();
        }

    }
}
