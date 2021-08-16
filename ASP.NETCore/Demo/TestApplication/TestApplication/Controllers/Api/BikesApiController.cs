using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;

namespace TestApplication.Controllers.Api
{
    [ApiController]
    [Route("api/bikes")]
    public class BikesApiController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BikesApiController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable GetCar()
        {
            return this.dbContext.Bikes.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(string id)
        {
            var bike = this.dbContext.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }
            return Ok(bike);
        }
    }
}
