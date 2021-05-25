using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class DateTimeController : Controller
    {
        public IActionResult Now()
        {
            var storedDate = this.HttpContext.Session.GetString("CurrentDate");
            if (storedDate == null)
            {
                storedDate = DateTime.Now.ToString();
                this.HttpContext.Session.SetString("CurrentDate", storedDate);
            }

            return Ok(storedDate);
        }
    }
}
