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
    public class SubjectDepartmentsController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;

        public SubjectDepartmentsController(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/SubjectDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDepartment>>> GetSubjectDepartments()
        {
            return await _context.SubjectDepartments.ToListAsync();
        }

        // GET: api/SubjectDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDepartment>> GetSubjectDepartment(string id)
        {
            var subjectDepartment = await _context.SubjectDepartments.FindAsync(id);

            if (subjectDepartment == null)
            {
                return NotFound();
            }

            return subjectDepartment;
        }

        // PUT: api/SubjectDepartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectDepartment(string id, SubjectDepartment subjectDepartment)
        {
            if (id != subjectDepartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectDepartmentExists(id))
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

        // POST: api/SubjectDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectDepartment>> PostSubjectDepartment(SubjectDepartment subjectDepartment)
        {
            _context.SubjectDepartments.Add(subjectDepartment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubjectDepartmentExists(subjectDepartment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubjectDepartment", new { id = subjectDepartment.Id }, subjectDepartment);
        }

        // DELETE: api/SubjectDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectDepartment(string id)
        {
            var subjectDepartment = await _context.SubjectDepartments.FindAsync(id);
            if (subjectDepartment == null)
            {
                return NotFound();
            }

            _context.SubjectDepartments.Remove(subjectDepartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectDepartmentExists(string id)
        {
            return _context.SubjectDepartments.Any(e => e.Id == id);
        }
    }
}
