using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Data.Models;
using TestApplication.Models.Bikes;

namespace TestApplication.Controllers
{
    public class BikesController : Controller
    {
        private readonly ApplicationDbContext data;

        public BikesController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var bikes = this.data
                .Bikes
                .Select(x => new BikeViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    Category = x.Category.Name
                })
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .ToList();
            return View(bikes);
        }

        public IActionResult Review(BikeSearchQueryModel query)
        {
            var bikesQuery = this.data.Bikes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Brand))
            {
                bikesQuery = bikesQuery.Where(x => x.Brand == query.Brand);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                bikesQuery = bikesQuery.Where(x =>
                    (x.Brand + " " + x.Model).ToLower().Contains(query.SearchTerm.ToLower()) ||
                    x.Description.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            bikesQuery = query.Sorting switch
            {
                BikeSorting.Year => bikesQuery.OrderByDescending(x => x.Year),
                BikeSorting.BrandAndModel => bikesQuery.OrderBy(x => x.Brand).ThenBy(x => x.Model),
                _ => bikesQuery.OrderByDescending(x => x.Id)
            };

            var bikes = bikesQuery
                .Select(x => new BikeDetailsViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    Category = x.Category.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl
                })
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .ToList();

            var bikeBrands = this.data
                .Bikes
                .Select(x => x.Brand)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            query.Brands = bikeBrands;
            query.Bikes = bikes;

            return View(query);
        }

        public IActionResult Details(string id)
        {
            var bike = this.data.Bikes
                .Where(x => x.Id == id)
                .Select(x => new BikeDetailsViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    Category = x.Category.Name,
                    Description = x.Description
                })
                .FirstOrDefault();
            return View(bike);
        }

        public IActionResult Create() => View(new CreateBikeFormModel
        {
            Categories = this.GetBikeCategories()
        });

        [HttpPost]
        public IActionResult Create(CreateBikeFormModel bike)
        {
            if (!this.data.Categories.Any(x => x.Id == bike.CategoryId))
            {
                this.ModelState
                    .AddModelError(nameof(bike.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                bike.Categories = this.GetBikeCategories();
                return View(bike);
            }

            var bikeData = new Bike
            {
                Brand = bike.Brand,
                Model = bike.Model,
                Description = bike.Description,
                ImageUrl = bike.ImageUrl,
                Year = bike.Year,
                CategoryId = bike.CategoryId
            };

            this.data.Bikes.Add(bikeData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IEnumerable<BikeCategoryViewModel> GetBikeCategories()
            => this.data
                .Categories
                .Select(x => new BikeCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
    }
}
