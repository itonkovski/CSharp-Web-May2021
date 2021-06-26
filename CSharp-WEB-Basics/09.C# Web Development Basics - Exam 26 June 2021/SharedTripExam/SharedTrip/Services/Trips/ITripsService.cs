using System;
using System.Collections.Generic;
using SharedTrip.Models.Trips;

namespace SharedTrip.Services.Trips
{
    public interface ITripsService
    {
        void Create(AddTripInputModel trip);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsModel GetDetails(string id);

        bool HasAvailableSeats(string tripId);

        bool AddUserToTrip(string userId, string tripId);
    }
}
