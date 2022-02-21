using AutoMapper;
using BusinessLogic.Dto.Auth;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Vm;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;

        public AuthService(AppDBContext context, UserManager<User> userManager,
             IMapper mapper, ITokenService tokenService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenService = tokenService;

        }

        public async Task<LoginViewModel> Login(LoginDto loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Login);

            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                var token = tokenService.GenerateJWT(claims);
                await context.SaveChangesAsync();
                return new LoginViewModel
                {
                    Token = token,
                };
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
            return res;
        }
    }
}
