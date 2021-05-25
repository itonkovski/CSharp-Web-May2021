using System;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            //Validate user and pass
            this.Response.Cookies.Append("Authentication", "Ivaylo_0502");

            return View();
        }
    }
}
