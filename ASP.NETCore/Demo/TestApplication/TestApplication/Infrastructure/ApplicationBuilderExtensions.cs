using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
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

            var data = scopedServices.ServiceProvider.GetService<ApplicationDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

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
    }
}
