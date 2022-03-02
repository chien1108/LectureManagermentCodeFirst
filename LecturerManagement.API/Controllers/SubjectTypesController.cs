using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectType;
using LecturerManagement.Services.SubjectTypeService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTypesController : ControllerBase
    {
        private readonly ISubjectTypeService _service;

        public SubjectTypesController(ISubjectTypeService subjectTypeService)
        {
            _service = subjectTypeService;
        }

        // GET: api/SubjectTypes
        /// <summary>
        /// Get All Subject Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetSubjectTypeDto>>>> GetSubjectTypes()
        {
            return Ok(await _service.GetAllSubjectType());
        }

        // GET: api/SubjectTypes/5
        /// <summary>
        /// Get Subject Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubjectTypeDto>>> GetSubjectType(string id)
        {
            var subjectType = await _service.GetSubjectTypeByCondition(x => x.Id.Trim().ToLower() == id.ToLower().Trim());

            if (subjectType.Data == null)
            {
                return NotFound();
            }

            return Ok(subjectType);
        }

        // PUT: api/SubjectTypes/5
        /// <summary>
        /// update Subject Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedSubjectType"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectType(string id, UpdateSubjectTypeDto updatedSubjectType)
        {
            if (updatedSubjectType == null)
            {
                return BadRequest();
            }
            if (!await SubjectTypeExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateSubjectType(updatedSubjectType, x => x.Id == id));
        }

        // POST: api/SubjectTypes
        /// <summary>
        /// Add New Subject Type
        /// </summary>
        /// <param name="subjectType"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetSubjectTypeDto>>> AddSubjectType(AddSubjectTypeDto subjectType)
        {
            if (subjectType == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _service.AddSubjectType(subjectType));
            }
        }

        // DELETE: api/SubjectTypes/5
        /// <summary>
        /// Delete Subject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectType(string id)
        {
            if (!await SubjectTypeExists(x => x.Id == id))
            {
                return NotFound();
            }
            await _service.DeleteSubjectType(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> SubjectTypeExists(Expression<Func<SubjectType, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}
