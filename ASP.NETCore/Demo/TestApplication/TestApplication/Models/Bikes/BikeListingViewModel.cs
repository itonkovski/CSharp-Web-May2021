using System;
namespace TestApplication.Models.Bikes
{
    public class BikeListingViewModel
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public string Category { get; set; }
    }
}
