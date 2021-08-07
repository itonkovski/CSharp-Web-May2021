using System;
using System.Collections.Generic;

namespace TestApplication.Services.Bikes
{
    public class BikeQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int BikesPerPage { get; set; }

        public int TotalBikes { get; set; }

        public IEnumerable<BikeServiceModel> Bikes { get; set; }
    }
}
