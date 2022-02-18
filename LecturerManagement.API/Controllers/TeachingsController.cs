using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingsController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;

        public TeachingsController(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Teachings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teaching>>> GetTeachings()
        {
            return await _context.Teachings.ToListAsync();
        }

        // GET: api/Teachings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teaching>> GetTeaching(string id)
        {
            var teaching = await _context.Teachings.FindAsync(id);

            if (teaching == null)
            {
                return NotFound();
            }

            return teaching;
        }

        // PUT: api/Teachings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeaching(string id, Teaching teaching)
        {
            if (id != teaching.SubjectID)
            {
                return BadRequest();
            }

            _context.Entry(teaching).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachingExists(id))
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

        // POST: api/Teachings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teaching>> PostTeaching(Teaching teaching)
        {
            _context.Teachings.Add(teaching);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeachingExists(teaching.SubjectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeaching", new { id = teaching.SubjectID }, teaching);
        }

        // DELETE: api/Teachings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeaching(string id)
        {
            var teaching = await _context.Teachings.FindAsync(id);
            if (teaching == null)
            {
                return NotFound();
            }

            _context.Teachings.Remove(teaching);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachingExists(string id)
        {
            return _context.Teachings.Any(e => e.SubjectID == id);
        }
    }
}
