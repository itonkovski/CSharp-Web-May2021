using System;
using System.Collections.Generic;
using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void Create(string userId, AddCarInputModel model);

        IEnumerable<CarViewModel> GetAll();
    }
}
