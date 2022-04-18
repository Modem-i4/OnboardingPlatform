using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RegistrationDate = DateTime.UtcNow;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
