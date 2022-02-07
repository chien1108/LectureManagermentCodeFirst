using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedLearningsController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;

        public AdvancedLearningsController(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/AdvancedLearnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvancedLearning>>> GetAdvancedLearnings()
        {
            return await _context.AdvancedLearnings.ToListAsync();
        }

        // GET: api/AdvancedLearnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvancedLearning>> GetAdvancedLearning(int id)
        {
            var advancedLearning = await _context.AdvancedLearnings.FindAsync(id);

            if (advancedLearning == null)
            {
                return NotFound();
            }

            return advancedLearning;
        }

        // PUT: api/AdvancedLearnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvancedLearning(int id, AdvancedLearning advancedLearning)
        {
            if (id != advancedLearning.Id)
            {
                return BadRequest();
            }

            _context.Entry(advancedLearning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvancedLearningExists(id))
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

        // POST: api/AdvancedLearnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdvancedLearning>> PostAdvancedLearning(AdvancedLearning advancedLearning)
        {
            _context.AdvancedLearnings.Add(advancedLearning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvancedLearning", new { id = advancedLearning.Id }, advancedLearning);
        }

        // DELETE: api/AdvancedLearnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvancedLearning(int id)
        {
            var advancedLearning = await _context.AdvancedLearnings.FindAsync(id);
            if (advancedLearning == null)
            {
                return NotFound();
            }

            _context.AdvancedLearnings.Remove(advancedLearning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvancedLearningExists(int id)
        {
            return _context.AdvancedLearnings.Any(e => e.Id == id);
        }
    }
}
