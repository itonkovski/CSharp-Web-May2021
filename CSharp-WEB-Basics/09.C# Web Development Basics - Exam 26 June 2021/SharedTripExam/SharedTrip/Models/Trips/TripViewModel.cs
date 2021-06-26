using System;
namespace SharedTrip.Models.Trips
{
    public class TripViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DapartureTime { get; set; }

        public int AvailableSeats
            => this.Seats - this.UsedSeats;

        public byte Seats { get; set; }

        public int UsedSeats { get; set; }
    }
}
