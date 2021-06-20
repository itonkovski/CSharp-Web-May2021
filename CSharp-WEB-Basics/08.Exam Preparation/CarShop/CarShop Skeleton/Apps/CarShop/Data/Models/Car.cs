using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models
{
    public class Car
    {
        //Has an Id – a string, Primary Key
        //Has a Model – a string with min length 5 and max length 20 (required)
        //Has a Year – a number(required)
        //Has a PictureUrl – string (required)
        //Has a PlateNumber – a string – Must be a valid Plate number(2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters (required)
        //Has a OwnerId – a string (required)
        //Has a Owner – a User object
        //Has Issues collection – an Issue type

        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Issues = new HashSet<Issue>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
