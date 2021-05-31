﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/users/login", new UsersControllers().Login));
            routeTable.Add(new Route("/users/register", new UsersControllers().Register));
            routeTable.Add(new Route("/cards/all", new CardsController().All));
            routeTable.Add(new Route("/cards/add", new CardsController().Add));
            routeTable.Add(new Route("/cards/collection", new CardsController().Collection));

            await Host.CreateHostAsync(routeTable, 3005);
        }
    }
}
