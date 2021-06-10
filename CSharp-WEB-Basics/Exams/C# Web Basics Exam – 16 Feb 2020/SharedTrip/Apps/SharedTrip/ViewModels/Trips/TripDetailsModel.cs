using System;
namespace SharedTrip.ViewModels.Trips
{
    public class TripDetailsModel : TripViewModel
    {
        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string DepartureTimeFormatted
            => this.DapartureTime.ToString("s");
    }
}
