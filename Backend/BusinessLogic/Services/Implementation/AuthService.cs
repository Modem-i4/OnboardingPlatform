using AutoMapper;
using BusinessLogic.Dto.Auth;
using BusinessLogic.Services.Abstract;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        
        public AuthService(AppDBContext context, UserManager<User> userManager,
             IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
           
        }

        public async Task<IdentityResult> Registration(RegistrationDto registerDto)
        {
            var newUser = mapper.Map<User>(registerDto);

            var res = await userManager.CreateAsync(newUser, registerDto.Password);
            return res;
        }
    }
}
