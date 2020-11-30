using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models;
using API.Models.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class restaurantController : ControllerBase
    {
        // GET: api/restaurant
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Restaurants> Get()
        {
            IGetAllRestaurants readObject = new ReadRestaurantData();
            return readObject.GetAllRestaurants();
        }

        // GET: api/restaurant/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Restaurants Get(int id)
        {
            IGetRestaurant readObject = new ReadRestaurantData();
            return readObject.GetRestaurant(id);
        }

        // POST: api/restaurant
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Restaurants value)
        {
            IInsertRestaurant insertObject = new SaveRestaurant();
            insertObject.InsertRestaurant(value);
        }

        // PUT: api/restaurant/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteRestaurant deleteObject = new DeleteRestaurant();
            deleteObject.RemoveRestaurant(id);
        }
    }
}
