using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models
{
    public class Issue
    {
        //Has an Id – a string, Primary Key
        //Has a Description – a string with min length 5 (required)
        //Has a IsFixed – a bool indicating if the issue has been fixed or not (required)
        //Has a CarId – a string (required)
        //Has Car – a Car object

        public Issue()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }
    }
}