using System;
using System.Collections.Generic;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(AddTripInputModel trip);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsModel GetDetails(string id);
    }
}
