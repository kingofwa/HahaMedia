using Microsoft.AspNetCore.Identity;
using HahaMedia.Infrastructure.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HahaMedia.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
        {
            //Seed Roles
            if (!roleManager.Roles.Any() && !await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new ApplicationRole("Admin"));
        }
    }
}
