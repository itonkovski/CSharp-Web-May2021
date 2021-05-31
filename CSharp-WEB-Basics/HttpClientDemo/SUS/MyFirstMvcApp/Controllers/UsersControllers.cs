using System;
using System.IO;
using System.Text;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersControllers : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login...<h1/>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponse Register(HttpRequest request)
        {
            var responseHtml = File.ReadAllText("Views/Users/Register.html");
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }
    }
}
