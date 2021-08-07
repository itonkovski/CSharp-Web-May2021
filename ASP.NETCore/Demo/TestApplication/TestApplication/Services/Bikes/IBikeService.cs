using System;
using System.Collections.Generic;
using TestApplication.Models.Bikes;

namespace TestApplication.Services.Bikes
{
    public interface IBikeService
    {
        BikeQueryServiceModel All(
            string brand,
            string searchTerm,
            BikeSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<string> AllBikeBrands();
    }
}
