using System;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MishMash.Controllers
{
    public class ChannelsController : Controller
    {
        public HttpResponse Create()
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }

        public HttpResponse Followed()
        {
            return this.View();
        }
    }
}
