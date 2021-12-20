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
    public class NonFoodController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly NonFoodService _nonFoodService;

        public NonFoodController(ShopContext context, NonFoodService service)
        {
            _context = context;
            _nonFoodService = service;
        }

        // GET: api/NonFood
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonFood>>> GetNonFoods()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            return Ok(await _nonFoodService.GetNonFoods());
        }

        // GET: api/NonFood/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NonFood>> GetNonFood(int id)
        {
            try
            {
                var nonFood = await _nonFoodService.GetNonFood(id);

                if (nonFood == null)
                {
                    return NotFound();
                }

                return Ok(nonFood);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // PUT: api/NonFood/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNonFood(int id, NonFood nonFood)
        {
            if (id != nonFood.Id)
            {
                return BadRequest();
            }

            try
            {
                var nonFoodresult = await _nonFoodService.PutNonFood(id, nonFood);
                if (nonFood == null)
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

        // POST: api/NonFood
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NonFood>> PostNonFood(NonFood nonFood)
        {
            try
            {
                var nonFoodresult = await _nonFoodService.PostNonFood(nonFood);
                return CreatedAtAction("GetNonFood", new { id = nonFoodresult.Id }, nonFoodresult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database");
            }
        }

        // DELETE: api/NonFood/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNonFood(int id)
        {
            try
            {
                var nonFood = await _nonFoodService.DeleteNonFood(id);
                if (nonFood == null)
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
