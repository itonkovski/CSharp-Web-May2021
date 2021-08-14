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

        public void All(AllBikesQueryModel queryModel)
        {
            var bikesQuery = this.data
                .Bikes
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Brand))
            {
                bikesQuery = bikesQuery.Where(x => x.Brand == queryModel.Brand);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                bikesQuery = bikesQuery.Where(x =>
                    (x.Brand + " " + x.Model).ToLower().Contains(queryModel.SearchTerm.ToLower()) ||
                    x.Description.ToLower().Contains(queryModel.SearchTerm.ToLower()));
            }

            bikesQuery = queryModel.Sorting switch
            {
                BikeSorting.Year => bikesQuery.OrderByDescending(x => x.Year),
                BikeSorting.BrandAndModel => bikesQuery.OrderBy(x => x.Brand).ThenBy(x => x.Model),
                _ => bikesQuery.OrderByDescending(x => x.Id)
            };

            var bikes = bikesQuery
                .OrderByDescending(c => c.Id)
                .Select(x => new BikeListingViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    ImageUrl = x.ImageUrl,
                    Category = x.Category.Name
                })
                .ToList();

            var bikeBrands = this.data
                .Bikes
                .Select(x => x.Brand)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            queryModel.Brands = bikeBrands;
            queryModel.Bikes = bikes;
        }
    }
}
