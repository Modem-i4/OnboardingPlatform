using Microsoft.AspNetCore.Identity;
using System;

namespace DataAccess.Models
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RegistrationDate = DateTime.Now;
           
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
