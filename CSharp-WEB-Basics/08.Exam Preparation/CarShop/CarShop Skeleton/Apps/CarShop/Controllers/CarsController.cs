using System;
using System.Text.RegularExpressions;
using CarShop.Data;
using CarShop.Services;
using CarShop.ViewModels.Cars;
using SUS.HTTP;
using SUS.MvcFramework;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext db;

        public CarsController(ICarsService carsService, IUsersService usersService, ApplicationDbContext db)
        {
            this.carsService = carsService;
            this.usersService = usersService;
            this.db = db;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarViewModel model)
        {
            ////var userId = this.GetUserId();
            ////if (this.IsUserSignedIn() ||
            ////    !this.usersService.IsUserMechanic(userId))
            ////{

            ////}
            //if (!this.IsUserSignedIn())
            //{
            //    return this.Redirect("/Users/Login");
            //}

            //if (string.IsNullOrEmpty(model.Model) ||
            //    model.Model.Length < 5 ||
            //    model.Model.Length > 20)
            //{
            //    return this.Error("Model should be between 5 and 20 characters long.");
            //}

            //if (model.Year < 1900 || model.Year > 2100)
            //{
            //    return this.Error("The year should be between 1900 and 2100.");
            //}

            //if (string.IsNullOrEmpty(model.Image))
            //{
            //    return this.Error("Image needs to be uploaded.");
            //}

            //if (!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            //{
            //    return this.Error("Image url should be valid.");
            //}

            ////!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}")
            //if (string.IsNullOrEmpty(model.PlateNumber))
            //{
            //    return this.Error($"Car plate number {model.PlateNumber} is not valid. It should be in format 'AA0000AA'.");
            //}
            //var userId = GetUserId();
            //this.carsService.Create(userId, model);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cars = this.carsService.GetAll();
            return this.View(cars);
        }
    }
}   
