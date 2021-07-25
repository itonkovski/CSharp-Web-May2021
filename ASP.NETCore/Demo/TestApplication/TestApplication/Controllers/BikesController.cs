using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Data.Models;
using TestApplication.Infrastructure;
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

            var totalBikes = bikesQuery.Count();

            var bikes = bikesQuery
                .Skip((query.CurrentPage - 1) * BikeSearchQueryModel.BikesPerPage)
                .Take(BikeSearchQueryModel.BikesPerPage)
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
            query.TotalBikes = totalBikes;

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

        [Authorize]
        public IActionResult Create()
        {
            if (!this.UserIsDealer())
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            return View(new CreateBikeFormModel
            {
                Categories = this.GetBikeCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateBikeFormModel bike)
        {
            var dealerId = this.data
                .Dealers
                .Where(x => x.UserId == this.User.GetId())
                .Select(x => x.Id)
                .FirstOrDefault();

            if (dealerId == 0)
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

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
                CategoryId = bike.CategoryId,
                DealerId = dealerId
            };

            this.data.Bikes.Add(bikeData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private bool UserIsDealer()
            => this.data
                .Dealers
                .Any(x => x.UserId == this.User.GetId());

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
