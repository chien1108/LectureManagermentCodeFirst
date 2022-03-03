using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Subject;
using LecturerManagement.Services.SubjectService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectsController(ISubjectService subjectService)
        {
            _service = subjectService;
        }

        // GET: api/Subjects
        /// <summary>
        /// Get All Subject
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetSubjectDto>>>> GetSubjects()
        {
            return Ok(await _service.GetAllSubject());
        }

        // GET: api/Subjects/5
        /// <summary>
        /// Get Subject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubjectDto>>> GetSubject(string id)
        {
            var subject = await _service.GetSubjectByCondition(x => x.Id.Trim().ToLower() == id.ToLower().Trim());

            if (subject.Data == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/Subjects/5
        /// <summary>
        /// Update Subject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(string id, UpdateSubjectDto subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }
            if (!await SubjectExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateSubject(subject, x => x.Id == id));
        }

        // POST: api/Subjects
        /// <summary>
        /// Add New Subject to Db
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetSubjectDto>>> AddSubject(AddSubjectDto subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _service.AddSubject(subject));
            }
        }

        // DELETE: api/Subjects/5
        /// <summary>
        /// Delete Subject By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(string id)
        {
            if (!await SubjectExists(x => x.Id == id))
            {
                return NotFound();
            }
            await _service.DeleteSubject(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> SubjectExists(Expression<Func<Subject, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}
