using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class CatsController : Controller
    {
        public IActionResult List()
        {
            //this.Response.Headers.Add("Content-Disposition", "attachment");
            //return File("/path/to/pdf", "application/pdf");

            //return Redirect("/cats/search");

            var requestCookies = this.Request.Cookies;

            if (!requestCookies.ContainsKey("Authentication"))
            {
                return Unauthorized();
            }

            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
