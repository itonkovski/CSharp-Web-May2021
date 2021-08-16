using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.Data;
using TestApplication.Data.Models;

namespace TestApplication.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            var data = serviceProvider.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();

            SeedCategories(data);
            SeedAdministrator(serviceProvider, data);

            return app;
        }

        private static void SeedCategories(ApplicationDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Mountain Bikes" },
                new Category { Name = "Hybrid Bikes" },
                new Category { Name = "Folding Bikes" },
                new Category { Name = "Electric Bikes" },
                new Category { Name = "Touring Bikes" },
                new Category { Name = "Womens Bikes" },
                new Category { Name = "Kids Bikes" },
                new Category { Name = "City Bikes" },
                new Category { Name = "Gravel Bikes" },
                new Category { Name = "BMX Bikes" }
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services, ApplicationDbContext data)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Admin"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Admin" };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "itonkovski3@gmail.com";
                    const string adminPassword = "itonkovski2N.";

                    var user = new IdentityUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();

            data.SaveChanges();
        }
    }
}
