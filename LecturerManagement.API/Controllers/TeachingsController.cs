using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Teaching;
using LecturerManagement.Services.TeachingService;
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
    public class TeachingsController : ControllerBase
    {
        private readonly ITeachingService _service;

        public TeachingsController(ITeachingService teachingService)
        {
            _service = teachingService;
        }

        // GET: api/Teachings
        /// <summary>
        /// Get List Teaching
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetTeachingDto>>>> GetTeachings()
        {
            return Ok(await _service.GetAllTeaching());
        }

        // GET: api/Teachings/5
        /// <summary>
        /// Get Single Teaching By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTeachingDto>>> GetTeaching(string id)
        {
            var teaching = await _service.GetTeachingByCondition(x => x.Id == id);

            if (teaching.Data == null)
            {
                return NotFound();
            }

            return Ok(teaching);
        }

        // PUT: api/Teachings/5
        /// <summary>
        /// Update Teaching By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teaching"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTeachingDto>>> UpdateTeaching(string id, UpdateTeachingDto teaching)
        {
            if (teaching == null)
            {
                return BadRequest();
            }
            if (!await TeachingExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateTeaching(teaching, x => x.Id == id));
        }

        // POST: api/Teachings
        /// <summary>
        /// Add New Teaching
        /// </summary>
        /// <param name="teaching"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetTeachingDto>>> AddTeaching(AddTeachingDto teaching)
        {
            if (teaching == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _service.AddTeaching(teaching));
            }
        }

        // DELETE: api/Teachings/5
        /// <summary>
        /// Delete Teaching By Id
        /// </summary>
        /// <param name="id">ID For Delete Element</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeaching(string id)
        {
            if (!await TeachingExists(x => x.Id == id))
            {
                return NotFound();
            }
            await _service.DeleteTeaching(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> TeachingExists(Expression<Func<Teaching, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}
