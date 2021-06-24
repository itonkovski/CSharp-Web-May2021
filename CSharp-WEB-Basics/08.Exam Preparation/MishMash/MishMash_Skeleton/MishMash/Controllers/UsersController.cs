using System;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MishMash.Controllers
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

        public HttpResponse Logout()
        {
            if (this.IsUserSignedIn())
            {
                this.SignOut();
            }
            return this.Redirect("/");
        }
    }
}
