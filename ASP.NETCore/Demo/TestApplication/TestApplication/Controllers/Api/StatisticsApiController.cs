using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Models.Api.Statistics;

namespace TestApplication.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : Controller

    {
        private readonly ApplicationDbContext dbContext;

        public StatisticsApiController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var totalBikes = this.dbContext
                .Bikes.Count();

            var totalUsers = this.dbContext
                .Users.Count();

            var statistics = new StatisticsResponseModel
            {
                TotalBikes = totalBikes,
                TotalUsers = totalUsers,
                TotalRents = 0
            };

            return statistics;
        }
    }
}
