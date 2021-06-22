using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string userId, AddCarViewModel model)
        {
            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber
            };
            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            var cars = this.db.Cars.Select(x => new CarViewModel
            {
                Image = x.PictureUrl,
                Model = x.Model,
                Year = x.Year,
                PlateNumber = x.PlateNumber
            }).ToList();
            return cars;
        }
    }
}
