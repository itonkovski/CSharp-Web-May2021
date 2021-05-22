using System;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class CatsController : Controller
    {
        public IActionResult List()
        {
            return Redirect("/cats/search");
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
