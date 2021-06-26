using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SharedTrip.Data;
using SharedTrip.Models.Trips;

namespace SharedTrip.Services.Trips
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddTripInputModel model)
        {
            var dbTrip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DapartureTime = DateTime.ParseExact(model.DapartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = (byte)model.Seats,
                Description = model.Description,
            };
            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips
                .Select(x => new TripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DapartureTime = x.DapartureTime,
                    Seats = x.Seats,
                    UsedSeats = x.UserTrips.Count()
                })
                .ToList();
            return trips;
        }

        public TripDetailsModel GetDetails(string id)
        {
            var trip = this.db.Trips
                .Where(x => x.Id == id)
                .Select(x => new TripDetailsModel
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DapartureTime = x.DapartureTime,
                    Seats = x.Seats,
                    Description = x.Description,
                    UsedSeats = x.UserTrips.Count()
                })
                .FirstOrDefault();
            return trip;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = db.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new
                {
                    x.Seats,
                    TakenSeats = x.UserTrips.Count()
                })
                .FirstOrDefault();
            var availableSeats = trip.Seats - trip.TakenSeats;
            if (availableSeats <= 0)
            {
                return false;
            }
            return true;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips
                .Any(x => x.UserId == userId && x.TripId == tripId);

            if (userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }
    }
}
