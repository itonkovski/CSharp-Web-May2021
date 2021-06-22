using System;
using System.Collections.Generic;
using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void Create(string userId, AddCarViewModel model);

        IEnumerable<CarViewModel> GetAll();
    }
}
