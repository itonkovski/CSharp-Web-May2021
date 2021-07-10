using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Data.Models;
using TestApplication.Models;
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
            return View();
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

            return RedirectToAction("Index", "Home");
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
