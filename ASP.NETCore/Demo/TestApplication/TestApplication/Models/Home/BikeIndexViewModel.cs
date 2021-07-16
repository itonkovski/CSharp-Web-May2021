using System;
using System.Collections.Generic;

namespace TestApplication.Models.Home
{
    public class BikeIndexViewModel
    {
        public int TotalBikes { get; set; }

        public int TotalUsers { get; set; }

        public int TotalPopups { get; set; }

        public List<BikeIndexViewModel> Bikes { get; set; }
    }
}
