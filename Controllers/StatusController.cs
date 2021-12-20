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
    public class StatusController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly StatusService _statusService;

        public StatusController(ShopContext context, StatusService service)
        {
            _context = context;
            _statusService = service;
        }

        // GET: api/Status
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            return Ok(await _statusService.GetStatuses());
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            try
            {
                var status = await _statusService.GetStatus(id);

                if (status == null)
                {
                    return NotFound();
                }

                return Ok(status);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            try
            {
                var statusresult = await _statusService.PutStatus(id, status);
                if (status == null)
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

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            try
            {
                var statusresult = await _statusService.PostStatus(status);
                return CreatedAtAction("GetStatus", new { id = statusresult.Id }, statusresult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database");
            }
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            try
            {
                var status = await _statusService.DeleteStatus(id);
                if (status == null)
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
