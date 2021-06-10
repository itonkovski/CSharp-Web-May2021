using System;
using System.Globalization;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddTripInputModel trip)
        {
            var dbTrip = new Trip
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DapartureTime = DateTime.ParseExact(trip.DapartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = trip.ImagePath,
                Seats = (byte)trip.Seats,
                Description = trip.Description,
            };
            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }
    }
}
