using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.StandardTime;
using LecturerManagement.Services.StandardTimeService;
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
    public class StandardTimesController : ControllerBase
    {
        private readonly IStandardTimeService _service;

        public StandardTimesController(IStandardTimeService service)
        {
            _service = service;
        }

        // GET: api/StandardTimes
        /// <summary>
        /// Get All StandardTime
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStandardTime")]
        public async Task<ActionResult<IEnumerable<GetStandardTimeDto>>> GetStandardTimes()
        {
            return Ok(await _service.GetAllStandardTime());
        }

        // GET: api/StandardTimes/5
        /// <summary>
        /// Get Single Standard Time
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStandardTimeDto>>> GetStandardTime(string id)
        {
            var response = await _service.GetStandardTimeByCondition(x => x.Id == id);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        // PUT: api/StandardTimes/5
        /// <summary>
        /// Update Standard Time
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedStandardTime"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStandardTimeDto>>> UpdateStandardTime(string id, UpdateStandardTimeDto updatedStandardTime)
        {

            if (!await StandardTimeExists(x => x.Id == id))
            {
                return NotFound();
            }
            var response = await _service.UpdateStandardTime(updatedStandardTime, expression: x => x.Id.Trim().ToLower() == id.Trim().ToLower());
            return Ok(response);
        }

        // POST: api/StandardTimes
        /// <summary>
        /// Add Standard Time
        /// </summary>
        /// <param name="newStandardTime"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetStandardTimeDto>>> AddStandardTime(AddStandardTimeDto newStandardTime)
        {
            if (newStandardTime == null)
            {
                return BadRequest();
            }
            return Ok(await _service.AddStandardTime(newStandardTime));
        }

        // DELETE: api/StandardTimes/5
        /// <summary>
        /// Delete Standard Time By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStandardTimeDto>>> DeleteStandardTime(string id)
        {
            if (!await StandardTimeExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(_service.DeleteStandardTime(x => x.Id.Trim().ToLower() == id.Trim().ToLower()));
        }

        private async Task<bool> StandardTimeExists(Expression<Func<StandardTime, bool>> expression = null)
        {
            var response = await _service.IsExisted(expression);
            return response.Success;
        }
    }
}
