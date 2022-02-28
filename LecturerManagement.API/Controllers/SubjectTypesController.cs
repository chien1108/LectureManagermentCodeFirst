using AutoMapper;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectType;
using LecturerManagement.Services.SubjectTypeService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTypesController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;
        private readonly ISubjectTypeService _subjectTypeService;
        private readonly IMapper _mapper;

        public SubjectTypesController(LecturerManagementSystemDbContext context, ISubjectTypeService subjectTypeService, IMapper mapper)
        {
            _context = context;
            _subjectTypeService = subjectTypeService;
            _mapper = mapper;
        }

        // GET: api/SubjectTypes
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetSubjectTypeDto>>>> GetSubjectTypes()
        {
            return Ok(await _subjectTypeService.GetAllSubjectType());
        }

        // GET: api/SubjectTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubjectTypeDto>>> GetSubjectType(string id)
        {
            var subjectType = await _subjectTypeService.GetSubjectTypeByCondition(x => x.Id.Trim().ToLower() == id.ToLower().Trim());

            if (subjectType.Data == null)
            {
                return NotFound();
            }

            return subjectType;
        }

        // PUT: api/SubjectTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectType(string id, UpdateSubjectTypeDto updatedSubjectType)
        {

            if (updatedSubjectType == null)
            {
                return BadRequest();
            }
            if (!await SubjectTypeExists(id))
            {
                return NotFound();
            }

            return Ok(await _subjectTypeService.UpdateSubjectType(id, updatedSubjectType));
        }

        // POST: api/SubjectTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectType>> PostSubjectType(SubjectType subjectType)
        {
            //_context.SubjectTypes.Add(subjectType);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (SubjectTypeExists(subjectType.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

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

        private async Task<bool> SubjectTypeExists(string id)
        {
            return await _subjectTypeService.IsExisted(x => x.Id.ToLower().Trim() == id.ToLower().Trim());
        }
    }
}
