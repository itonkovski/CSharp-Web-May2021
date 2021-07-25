using System;
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

        public string Create(string brand, string model, string description, string imageUrl, int year, string categoryId, int dealerId)
        {
            var bikeData = new Bike
            {
                Brand = brand,
                Model = model,
                Description = description,
                ImageUrl = imageUrl,
                Year = year,
                CategoryId = categoryId,
                DealerId = dealerId
            };

            this.data.Bikes.Add(bikeData);
            this.data.SaveChanges();

            return bikeData.Id;
        }
    }
}
