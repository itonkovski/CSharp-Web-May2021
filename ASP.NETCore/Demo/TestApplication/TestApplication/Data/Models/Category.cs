using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Data.Models
{
    using static DataConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Bikes = new HashSet<Bike>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}