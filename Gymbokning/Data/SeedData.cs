using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Data
{
    public class SeedData
    {

        internal static async Task InitAsync(IServiceProvider services)
        {
            Debug.WriteLine("hello from seeder");

            using (var context = services.GetRequiredService<ApplicationDbContext>())
            {
                if (!context.Roles.Any(r => r.Name.Equals("Admin")))
                {
                    Debug.WriteLine("seeding a admin role");

                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    var role = new IdentityRole { Name = "Admin" };
                    var addRoleResult = await roleManager.CreateAsync(role);
                }

                if (!context.Users.Any(u => u.UserName.Equals("admin@Gymbokning.se")))
                {
                    Debug.WriteLine("seeding admin user");

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                    ApplicationUser adminUser = new ApplicationUser
                    {
                        UserName= "admin@Gymbokning.se",
                        Email= "admin@Gymbokning.se",
                        FirstName="Admin",
                        LastName="GymAdmin"
                    };

                    var result = await userManager.CreateAsync(adminUser, "sommar");

                    if (!result.Succeeded) throw new Exception(String.Join("\n", result.Errors));
                    
                    await userManager.AddToRoleAsync(adminUser, "Admin");



                }

            }
        }
    }
}
