using System;
namespace TestApplication.Models.Api.Statistics
{
    public class StatisticsResponseModel
    {
        public int TotalBikes { get; set; }

        public int TotalUsers { get; set; }

        public int TotalRents { get; set; }
    }
}
