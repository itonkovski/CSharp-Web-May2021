using System;
namespace SharedTrip.Data
{
    public class UserTrip
    {
        //Has UserId – a string
        //Has User – a User object
        //Has TripId– a string
        //Has Trip – a Trip object

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
