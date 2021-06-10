using System;
using System.Globalization;

namespace SharedTrip.ViewModels.Trips
{
    public class TripViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DapartureTime { get; set; }

        //You can use it in the Trips/View/All.cshtml file, if there are any special DateTime requirements
        //public string DepartureTimeAsString
        //    => this.DapartureTime.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int AvailableSeats
            => this.Seats - this.UsedSeats;

        public byte Seats { get; set; }

        public int UsedSeats { get; set; }
    }
}
