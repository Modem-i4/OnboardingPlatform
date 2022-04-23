using BusinessLogic.Dto.Auth;
using BusinessLogic.Vm;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Abstract
{
    public interface IAuthService
    {
        Task<LoginViewModel> Login(LoginDto loginModel);
        Task<IdentityResult> Registration(RegistrationDto registationDto);
        Task<IdentityResult> VerifyEmail(string idUser, string token);
    }
}
