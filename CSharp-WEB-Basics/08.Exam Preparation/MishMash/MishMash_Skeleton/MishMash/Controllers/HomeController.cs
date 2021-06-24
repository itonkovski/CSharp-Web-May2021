using System;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MishMash.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
