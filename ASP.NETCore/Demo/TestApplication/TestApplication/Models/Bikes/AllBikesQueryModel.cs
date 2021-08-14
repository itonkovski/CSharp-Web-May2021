using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models.Bikes
{
    public class AllBikesQueryModel
    {
        public string Brand { get; set; }

        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public BikeSorting Sorting { get; set; }

        public IEnumerable<BikeListingViewModel> Bikes { get; set; }
    }
}
