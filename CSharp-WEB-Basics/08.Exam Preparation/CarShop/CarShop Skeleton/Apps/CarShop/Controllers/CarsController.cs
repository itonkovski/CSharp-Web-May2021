using System;
using SUS.HTTP;
using SUS.MvcFramework;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        public HttpResponse Add() => View();

        //[HttpPost]
        //public HttpResponse Add()
        //{

        //}

        public HttpResponse All() => View();

        //[HttpPost]
        //public HttpResponse All()
        //{

        //}
    }
}
