using System;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Data.Models
{
    using static DataConstants;

    public class Bike
    {
        public Bike()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(BikeBrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(BikeModelMaxLength)]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
