﻿using System;
using System.Threading.Tasks;
using SUS.HTTP;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);

            server.AddRoute("/favicon.ico", Favicon);

            server.AddRoute("/about", About);

            server.AddRoute("/users/login", Login);

            await server.StartAsync(3005);
        }


        static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}