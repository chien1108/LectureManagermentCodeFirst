using AutoMapper;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Services.LecturerScientificResearchService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerScientificResearchesController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;
        private readonly ILecturerScientificResearchService _service;
        private readonly IMapper _mapper;

        public LecturerScientificResearchesController(LecturerManagementSystemDbContext context, ILecturerScientificResearchService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        // GET: api/LecturerScientificResearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturerScientificResearch>>> GetLecturerScientificResearches()
        {
            return await _context.LecturerScientificResearches.ToListAsync();
        }

        // GET: api/LecturerScientificResearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LecturerScientificResearch>> GetLecturerScientificResearch(string id)
        {
            var lecturerScientificResearch = await _context.LecturerScientificResearches.FindAsync(id);

            if (lecturerScientificResearch == null)
            {
                return NotFound();
            }

            return lecturerScientificResearch;
        }

        // PUT: api/LecturerScientificResearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecturerScientificResearch(string id, LecturerScientificResearch lecturerScientificResearch)
        {
            if (id != lecturerScientificResearch.Id)
            {
                return BadRequest();
            }

            _context.Entry(lecturerScientificResearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerScientificResearchExists(id))
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

        // POST: api/LecturerScientificResearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LecturerScientificResearch>> PostLecturerScientificResearch(LecturerScientificResearch lecturerScientificResearch)
        {
            _context.LecturerScientificResearches.Add(lecturerScientificResearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LecturerScientificResearchExists(lecturerScientificResearch.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLecturerScientificResearch", new { id = lecturerScientificResearch.Id }, lecturerScientificResearch);
        }

        // DELETE: api/LecturerScientificResearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturerScientificResearch(string id)
        {
            var lecturerScientificResearch = await _context.LecturerScientificResearches.FindAsync(id);
            if (lecturerScientificResearch == null)
            {
                return NotFound();
            }

            _context.LecturerScientificResearches.Remove(lecturerScientificResearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LecturerScientificResearchExists(string id)
        {
            return _context.LecturerScientificResearches.Any(e => e.Id == id);
        }
    }
}
