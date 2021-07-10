using System;
using System.Collections.Generic;

namespace TestApplication.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Bikes = new HashSet<Bike>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}