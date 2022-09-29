using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurant = _dbContext
                .Restaurants
                .ToList();

            return Ok(restaurant);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(e => e.Id == id);

            if(restaurant is null) return NotFound();

            return Ok(restaurant);
        }
    }
}
