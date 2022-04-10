using CollegWebApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CollegWebApp.DAL.Initializes
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("moderator"));
            }
            if (await roleManager.FindByNameAsync("teacher") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("teacher"));
            }
            if (await roleManager.FindByNameAsync("student") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("student"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User {
                    Email = adminEmail,
                    UserName = adminEmail,
                    Name = "Admin",
                    UserSurname = "Admin",
                    UserMiddleName = "Admin",
                    UserDataOfBirth = DateTime.Today
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
