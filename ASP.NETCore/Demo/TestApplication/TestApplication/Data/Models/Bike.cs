using System;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Data.Models
{
    using static DataConstants.Bike;

    public class Bike
    {
        public Bike()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public int DealerId { get; set; }

        public Dealer Dealer { get; set; }
    }
}
