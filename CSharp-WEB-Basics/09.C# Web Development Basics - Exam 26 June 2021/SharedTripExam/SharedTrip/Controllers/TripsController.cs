using System;
using System.Globalization;
using SharedTrip.Models.Trips;
using SharedTrip.Services.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetDetails(tripId);
            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Error("There are no available seats.");
            }

            var userId = this.GetUserId();
            if (!this.tripsService.AddUserToTrip(userId, tripId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return this.Error("Starting point is required.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return this.Error("End point is required.");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length > 80)
            {
                return this.Error("Description is required and has max length of 80 characters.");
            }

            if (!DateTime.TryParseExact(
                model.DapartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                return this.Error("Invalid departure time.");
            }

            this.tripsService.Create(model);
            return this.Redirect("/Trips/All");
        }
    }
}
