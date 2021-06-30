using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class BikesController : Controller
    {
        public IActionResult All()
        {
            var bikes = new List<BikeViewModel>
            {
                new BikeViewModel { Brand = "DBS", Price = 2356 },
                new BikeViewModel { Brand = "BMX", Price = 3100 },
                new BikeViewModel { Brand = "Giant", Price = 1900 }
            };

            return View(bikes);
        }

        public IActionResult Create() => View();
    }
}
