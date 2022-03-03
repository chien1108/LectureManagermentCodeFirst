using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectDepartment;
using LecturerManagement.Services.SubjectDepartmentService;
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
    public class SubjectDepartmentsController : ControllerBase
    {
        private readonly ISubjectDepartmentService _service;

        public SubjectDepartmentsController(ISubjectDepartmentService service)
        {
            _service = service;
        }

        // GET: api/SubjectDepartments
        /// <summary>
        /// Get All Subject Department
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDepartment>>> GetSubjectDepartments()
        {
            return Ok(await _service.GetAllSubjectDepartment());
        }

        // GET: api/SubjectDepartments/5
        /// <summary>
        /// Get Single Subject Department By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDepartment>> GetSubjectDepartment(string id)
        {
            var response = await _service.GetSubjectDepartmentByCondition(x => x.Id.Trim().ToLower() == id.ToLower().Trim());

            if (response.Data == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // PUT: api/SubjectDepartments/5
        /// <summary>
        /// Update Subject Department By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectDepartment"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubjectDepartmentDto>>> PutSubjectDepartment(string id, UpdateSubjectDepartmentDto subjectDepartment)
        {
            if (subjectDepartment == null)
            {
                return BadRequest();
            }
            if (!await SubjectDepartmentExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateSubjectDepartment(subjectDepartment, x => x.Id == id));
        }

        // POST: api/SubjectDepartments
        /// <summary>
        /// Add Subject Department
        /// </summary>
        /// <param name="subjectDepartment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetSubjectDepartmentDto>>> AddSubjectDepartment(AddSubjectDepartmentDto subjectDepartment)
        {
            if (subjectDepartment == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _service.AddSubjectDepartment(subjectDepartment));
            }
        }

        // DELETE: api/SubjectDepartments/5
        /// <summary>
        /// Delete Subject Department By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectDepartment(string id)
        {
            if (!await SubjectDepartmentExists(x => x.Id == id))
            {
                return NotFound();
            }
            await _service.DeleteSubjectDepartment(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> SubjectDepartmentExists(Expression<Func<SubjectDepartment, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}
