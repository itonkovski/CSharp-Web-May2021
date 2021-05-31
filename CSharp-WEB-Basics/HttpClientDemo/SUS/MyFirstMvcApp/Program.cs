using System;
using System.Threading.Tasks;
using MyFirstMvcApp.Controllers;
using SUS.HTTP;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            //server.AddRoute("/itonkovski", (request) =>
            //{
            //    return new HttpResponse("text/html", new byte[] { 0x56, 0x57 });
            //});

            server.AddRoute("/", new HomeController().Index);           

            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);

            server.AddRoute("/users/login", new UsersControllers().Login);

            server.AddRoute("/users/register", new UsersControllers().Register);

            server.AddRoute("/cards/all", new CardsController().All);

            server.AddRoute("/cards/add", new CardsController().Add);

            server.AddRoute("/cards/collection", new CardsController().Collection);

            await server.StartAsync(3005);
        }


        

        

        

        
    }
}
