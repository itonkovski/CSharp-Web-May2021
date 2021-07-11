using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.Data;
using TestApplication.Models.Bikes;

namespace TestApplication.Services.Bikes
{
    public class BikesService : IBikesService
    {
        private readonly ApplicationDbContext dbContext;

        public BikesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public IEnumerable<BikeViewModel> GetAll()
        //{
        //    var bikes = this.dbContext.Bikes
        //        .Select(x => new BikeViewModel
        //        {
        //            Id = x.Id,
        //            Brand = x.Brand,
        //            Model = x.Model,
        //            Year = x.Year,
        //            Category = x.Category.Name
        //        })
        //        .ToList();
        //    return bikes;
        //}
    }
}
