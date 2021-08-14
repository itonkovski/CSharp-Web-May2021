using System;
using System.Collections.Generic;
using TestApplication.Models.Bikes;

namespace TestApplication.Services.Bikes
{
    public interface IBikeService
    {
        public void All(AllBikesQueryModel bikeModel);
    }
}
