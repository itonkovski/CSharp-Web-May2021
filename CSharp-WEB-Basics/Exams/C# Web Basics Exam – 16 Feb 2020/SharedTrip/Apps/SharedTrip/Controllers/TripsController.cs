﻿using System;
using System.Globalization;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
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
            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Error("Starting point is required.");
            }

            if (string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Error("End point is required.");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(input.Description) ||
                input.Description.Length > 80)
            {
                return this.Error("Description is required and has max length of 80 characters.");
            }

            if (!DateTime.TryParseExact(
                input.DapartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                return this.Error("Invalid departure time. Please use dd.MM.yyyy HH:mm format");
            }

            this.tripsService.Create(input);
            return this.Redirect("/Trips/All");
        }
    }
}
