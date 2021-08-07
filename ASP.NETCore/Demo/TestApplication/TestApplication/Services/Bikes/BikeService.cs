using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.Data;
using TestApplication.Data.Models;
using TestApplication.Models.Bikes;

namespace TestApplication.Services.Bikes
{
    public class BikeService : IBikeService
    {
        private readonly ApplicationDbContext data;

        public BikeService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public BikeQueryServiceModel All(
            string brand,
            string searchTerm,
            BikeSorting sorting,
            int currentPage,
            int bikesPerPage)
        {
            var bikesQuery = this.data.Bikes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(brand))
            {
                bikesQuery = bikesQuery.Where(c => c.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                bikesQuery = bikesQuery.Where(c =>
                    (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            bikesQuery = sorting switch
            {
                BikeSorting.Year => bikesQuery.OrderByDescending(x => x.Year),
                BikeSorting.BrandAndModel => bikesQuery.OrderBy(x => x.Brand).ThenBy(x => x.Model),
                _ => bikesQuery.OrderByDescending(x => x.Id)
            };

            var totalBikes = bikesQuery.Count();

            var bikes = bikesQuery
                .Skip((currentPage - 1) * bikesPerPage)
                .Take(bikesPerPage)
                .Select(x => new BikeServiceModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Description = x.Description,
                    Year = x.Year,
                    Category = x.Category.Name,
                    ImageUrl = x.ImageUrl
                })
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .ToList();

            return new BikeQueryServiceModel
            {
                TotalBikes = totalBikes,
                CurrentPage = currentPage,
                BikesPerPage = bikesPerPage,
                Bikes = bikes
            };
        }

        public IEnumerable<string> AllBikeBrands()
            => this.data
                .Bikes
                .Select(c => c.Brand)
                .Distinct()
                .OrderBy(br => br)
                .ToList();
    }
}
