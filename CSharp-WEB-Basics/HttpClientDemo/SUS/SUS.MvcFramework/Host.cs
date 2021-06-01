﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SUS.HTTP;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int port = 3005)
        {
            IHttpServer server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }
    }
}
