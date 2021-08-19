using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Models.Bikes;
using TestApplication.Services.Bikes;

namespace TestApplication.Areas.Admin.Controllers
{
    public class BikesController : AdminController
    {
        private readonly IBikeService bikeService;

        public BikesController(IBikeService bikeService)
        {
            this.bikeService = bikeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All(AllBikesQueryModel queryModel)
        {
            this.bikeService.All(queryModel);
            return View(queryModel);
        }
    }
}
