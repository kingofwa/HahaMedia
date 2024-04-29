using Microsoft.AspNetCore.Identity;
using HahaMedia.Infrastructure.Identity.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HahaMedia.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@Admin.com",
                Name = "Le",
                PhoneNumber = "0365896510",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (!userManager.Users.Any())
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Le@12345");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }

            }
        }

    }
}
