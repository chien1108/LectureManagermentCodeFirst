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
    public class ScientificResearchGuidesController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;

        public ScientificResearchGuidesController(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/ScientificResearchGuides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScientificResearchGuide>>> GetScientificResearchGuides()
        {
            return await _context.ScientificResearchGuides.ToListAsync();
        }

        // GET: api/ScientificResearchGuides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScientificResearchGuide>> GetScientificResearchGuide(string id)
        {
            var scientificResearchGuide = await _context.ScientificResearchGuides.FindAsync(id);

            if (scientificResearchGuide == null)
            {
                return NotFound();
            }

            return scientificResearchGuide;
        }

        // PUT: api/ScientificResearchGuides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScientificResearchGuide(string id, ScientificResearchGuide scientificResearchGuide)
        {
            if (id != scientificResearchGuide.Id)
            {
                return BadRequest();
            }

            _context.Entry(scientificResearchGuide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScientificResearchGuideExists(id))
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

        // POST: api/ScientificResearchGuides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScientificResearchGuide>> PostScientificResearchGuide(ScientificResearchGuide scientificResearchGuide)
        {
            _context.ScientificResearchGuides.Add(scientificResearchGuide);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScientificResearchGuideExists(scientificResearchGuide.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScientificResearchGuide", new { id = scientificResearchGuide.Id }, scientificResearchGuide);
        }

        // DELETE: api/ScientificResearchGuides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScientificResearchGuide(string id)
        {
            var scientificResearchGuide = await _context.ScientificResearchGuides.FindAsync(id);
            if (scientificResearchGuide == null)
            {
                return NotFound();
            }

            _context.ScientificResearchGuides.Remove(scientificResearchGuide);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScientificResearchGuideExists(string id)
        {
            return _context.ScientificResearchGuides.Any(e => e.Id == id);
        }
    }
}
