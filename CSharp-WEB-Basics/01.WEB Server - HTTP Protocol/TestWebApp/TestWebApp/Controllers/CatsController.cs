using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class CatsController : Controller
    {
        private readonly DbContext data;

        public CatsController()
        {
            this.data = new DbContext();
        }

        public IActionResult List()
        {
            //this.Response.Headers.Add("Content-Disposition", "attachment");
            //return File("/path/to/pdf", "application/pdf");

            //return Redirect("/cats/search");

            //var requestCookies = this.Request.Cookies;

            //if (!requestCookies.ContainsKey("Authentication"))
            //{
            //    return Unauthorized();
            //}

            var cats = this.data
                .AllCats()
                .Select(c => new CatModel
                {
                    Name = c.Name,
                    Age = c.Age,
                    Owner = c.Owner.Name
                })
                .ToList();

            if (!cats.Any())
            {
                return NotFound();
            }

            return View(cats);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
