using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models.Bikes
{
    public class BikeSearchQueryModel
    {
        public const int BikesPerPage = 3;

        public string Brand { get; set; }

        public IEnumerable<string> Brands { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalBikes { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public BikeSorting Sorting { get; set; }

        public IEnumerable<BikeDetailsViewModel> Bikes { get; set; }
    }
}
