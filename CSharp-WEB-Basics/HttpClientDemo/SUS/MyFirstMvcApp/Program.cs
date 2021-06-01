using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 3005);
        }
    }
}
