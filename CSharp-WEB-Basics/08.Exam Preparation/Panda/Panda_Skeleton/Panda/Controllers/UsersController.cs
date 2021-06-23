using System;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Panda.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
