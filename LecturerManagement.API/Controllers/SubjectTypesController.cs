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
    public class SubjectTypesController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;

        public SubjectTypesController(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/SubjectTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectType>>> GetSubjectTypes()
        {
            return await _context.SubjectTypes.ToListAsync();
        }

        // GET: api/SubjectTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectType>> GetSubjectType(string id)
        {
            var subjectType = await _context.SubjectTypes.FindAsync(id);

            if (subjectType == null)
            {
                return NotFound();
            }

            return subjectType;
        }

        // PUT: api/SubjectTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectType(string id, SubjectType subjectType)
        {
            if (id != subjectType.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectTypeExists(id))
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

        // POST: api/SubjectTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectType>> PostSubjectType(SubjectType subjectType)
        {
            _context.SubjectTypes.Add(subjectType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubjectTypeExists(subjectType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubjectType", new { id = subjectType.Id }, subjectType);
        }

        // DELETE: api/SubjectTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectType(string id)
        {
            var subjectType = await _context.SubjectTypes.FindAsync(id);
            if (subjectType == null)
            {
                return NotFound();
            }

            _context.SubjectTypes.Remove(subjectType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectTypeExists(string id)
        {
            return _context.SubjectTypes.Any(e => e.Id == id);
        }
    }
}
