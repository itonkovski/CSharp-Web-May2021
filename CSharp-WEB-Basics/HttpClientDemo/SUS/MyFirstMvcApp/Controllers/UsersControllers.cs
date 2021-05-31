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
            return this.View("Views/Users/Login.html");
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View("Views/Users/Register.html");
        }
    }
}
