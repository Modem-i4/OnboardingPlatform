using BusinessLogic.Dto.Auth;
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
        Task<IdentityResult> Registration(RegistrationDto registationDto);
    }
}
