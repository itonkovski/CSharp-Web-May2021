using System;
using Panda.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Panda.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!IsUserSignedIn())
            {
                return this.View();
            }

            return this.Redirect("/Home/IndexLoggedIn");
        }

        public HttpResponse IndexLoggedIn()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.GetUserId();
            var userName = this.usersService.GetUsername(userId);

            var viewModel = new LoggedInHomeViewModel
            {
                Username = userName
            };

            return this.View(viewModel);
        }
    }
}
