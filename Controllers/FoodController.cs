using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularChallengeAPI.Data;
using AngularChallengeAPI.Models;
using Microsoft.AspNetCore.Authorization;
using AngularChallengeAPI.Services;

namespace AngularChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly FoodService _foodService;

        public FoodController(ShopContext context, FoodService service)
        {
            _context = context;
            _foodService = service;
        }

        // GET: api/Food
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            return Ok(await _foodService.GetFoods());
        }

        // GET: api/Food/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            try
            {
                var food = await _foodService.GetFood(id);

                if (food == null)
                {
                    return NotFound();
                }

                return Ok(food);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // PUT: api/Food/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            try
            {
                var foodresult = await _foodService.PutFood(id, food);
                if (food == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error writing changes to the database");
            }
        }

        // POST: api/Food
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            try
            {
                var foodresult = await _foodService.PostFood(food);
                return CreatedAtAction("GetFood", new { id = foodresult.Id }, foodresult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database");
            }
        }

        // DELETE: api/Food/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            try
            {
                var food = await _foodService.DeleteFood(id);
                if (food == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
