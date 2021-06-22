using System;
namespace CarShop.ViewModels.Cars
{
    public class CarViewModel
    {
        public string Image { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string PlateNumber { get; set; }

        public int FixedIssues { get; set; }

        public int UnfixedIssues { get; set; }
    }
}
