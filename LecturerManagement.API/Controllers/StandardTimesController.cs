using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.StandardTime;
using LecturerManagement.Services.StandardTimeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardTimesController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;
        private readonly IStandardTimeService _service;

        public StandardTimesController(LecturerManagementSystemDbContext context, IStandardTimeService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/StandardTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStandardTimeDto>>> GetStandardTimes()
        {
            return Ok(await _service.FindAll());
        }

        // GET: api/StandardTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StandardTime>> GetStandardTime(string id)
        {
            var standardTime = await _context.StandardTimes.FindAsync(id);

            if (standardTime == null)
            {
                return NotFound();
            }

            return standardTime;
        }

        // PUT: api/StandardTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandardTime(string id, StandardTime standardTime)
        {
            if (id != standardTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(standardTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardTimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StandardTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StandardTime>> PostStandardTime(StandardTime standardTime)
        {
            _context.StandardTimes.Add(standardTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StandardTimeExists(standardTime.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStandardTime", new { id = standardTime.Id }, standardTime);
        }

        // DELETE: api/StandardTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStandardTime(string id)
        {
            var standardTime = await _context.StandardTimes.FindAsync(id);
            if (standardTime == null)
            {
                return NotFound();
            }

            _context.StandardTimes.Remove(standardTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StandardTimeExists(string id)
        {
            return _context.StandardTimes.Any(e => e.Id == id);
        }
    }
}
