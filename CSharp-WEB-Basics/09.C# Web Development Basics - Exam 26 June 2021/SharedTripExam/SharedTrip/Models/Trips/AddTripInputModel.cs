﻿using System;
namespace SharedTrip.Models.Trips
{
    public class AddTripInputModel
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DapartureTime { get; set; }

        public string ImagePath { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }
    }
}
