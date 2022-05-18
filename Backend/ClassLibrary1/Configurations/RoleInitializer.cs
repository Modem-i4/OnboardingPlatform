using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string adminEmail = "kripaknomer1@gmail.com";
            string password = "string";

            if(await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("admin"));
                await roleManager.CreateAsync(new IdentityRole<int>("student"));
            }

            if(await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    FirstName = "Sasha",
                    LastName = "WAWAWA",
                    UserName = "WAWAWA",
                    Email = "kripaknomer1@gmail.com",
                    NormalizedEmail = "KRIPAKNOMER1@GMAIL.COM",
                    RegistrationDate = DateTime.UtcNow,
                    EmailConfirmed = true
                };
                User student = new User
                {
                    FirstName = "bogdan",
                    LastName = "Kekovich",
                    UserName = "Bogdanuch",
                    Email = "oleksandr.khirov@oa.edu.ua",
                    NormalizedEmail = "OLEKSANDR.KHIROV@OA.EDU.UA",
                    RegistrationDate = DateTime.UtcNow,
                    EmailConfirmed = true
                };
                
                
                var result = await userManager.CreateAsync(admin, password);
                var resultStudent = await userManager.CreateAsync(student, password);
                if (result.Succeeded && resultStudent.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                    await userManager.AddToRoleAsync(student, "student");
                }
            }
        }


    }
}
