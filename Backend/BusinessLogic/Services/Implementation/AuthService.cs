using AutoMapper;
using BusinessLogic.Dto.Auth;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Vm;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Templates;
using Templates.ViewModels;

namespace BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IRazorViewToStringRenderer razorViewToStringRenderer;
        private readonly IEmailService emailService;
        const string view = "Views/Emails/ConfirmAccountEmail";

        public AuthService(AppDBContext context, UserManager<User> userManager,
             IMapper mapper, ITokenService tokenService, IRazorViewToStringRenderer razorViewToStringRenderer,
            IEmailService emailService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.emailService = emailService;
            this.razorViewToStringRenderer = razorViewToStringRenderer;

        }

        public async Task<LoginViewModel> Login(LoginDto loginModel)
        {
           var user = await userManager.FindByEmailAsync(loginModel.Email);
           
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                  new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                  new Claim(ClaimTypes.Role, userRoles.First()),
                  new Claim(ClaimTypes.Name, user.UserName),
                };

                var token = tokenService.GenerateJWT(claims);
                var refreshToken = tokenService.GenerateRefreshToken();
               
                var loginViewModel = new LoginViewModel
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    UserId = user.Id,
                };

                var newRefreshToken = mapper.Map<UserRefreshToken>(loginViewModel);

                var users = await context.UserRefreshTokens.FirstOrDefaultAsync(u => u.UserId == user.Id);        

                if (users != null)
                {
                    context.UserRefreshTokens.Attach(users);
                    context.UserRefreshTokens.Remove(users);
                    await context.SaveChangesAsync();
                }
                await context.UserRefreshTokens.AddAsync(newRefreshToken);
                await context.SaveChangesAsync();

                return loginViewModel;

            }
            else
            {
                return null;
            }
        }

        public async Task<IdentityResult> Registration(RegistrationDto registerDto)
        {
            var newUser = mapper.Map<User>(registerDto);

            var res = await userManager.CreateAsync(newUser, registerDto.Password);
            
            if(res.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, "student");

                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                
                string confirmationLink = $"http://localhost:3000/confirmation/{newUser.Id}/{confirmationToken}";
                
                var confirmAccount = new ConfirmAccountEmailViewModel(confirmationLink);

                var toAddresses = newUser.Email;

                string body = await razorViewToStringRenderer.RenderViewToStringAsync($"{view}.cshtml", confirmAccount);

                await emailService.SendEmailAsync(toAddresses,
                    "Registration To The Course Project",
                   body);
            }
            
            return res;
        }

        public async Task<IdentityResult> VerifyEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null || token == null)
            {
                return IdentityResult.Failed();
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await userManager.ConfirmEmailAsync(user, token);
            return result;
        }
    }
}
