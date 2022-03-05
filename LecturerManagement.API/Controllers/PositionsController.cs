using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Position;
using LecturerManagement.Services.PositionService;
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
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _service;

        public PositionsController(IPositionService positionService)
        {
            _service = positionService;
        }

        // GET: api/Positions
        /// <summary>
        /// Get All Position
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetPositionDto>>>> GetPositions()
        {
            return Ok(await _service.GetAllPosition());
        }

        // GET: api/Positions/5
        /// <summary>
        /// Get Position By ID
        /// </summary>
        /// <param name="id">Id For Get Position Form Db</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPositionDto>>> GetPosition(string id)
        {
            var response = await _service.GetPositionByCondition(x => x.Id == id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        // PUT: api/Positions/5
        /// <summary>
        /// Update Position By Id
        /// </summary>
        /// <param name="id">Id Position Element for Update</param>
        /// <param name="updatePosition">Element Position For Update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(string id, UpdatePositionDto updatePosition)
        {
            if (updatePosition == null)
            {
                return BadRequest();
            }
            if (!await PositionExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdatePosition(updatePosition, x => x.Id == id));
        }

        // POST: api/Positions
        /// <summary>
        /// Add New Position to Database
        /// </summary>
        /// <param name="newPosition">New Position Element Object for Create</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetPositionDto>>> AddNewPosition(AddPositionDto newPosition)
        {
            if (newPosition == null)
            {
                return BadRequest();
            }

            return Ok(await _service.AddPosition(newPosition));
        }

        // DELETE: api/Positions/5
        /// <summary>
        /// Delete Positon by Id
        /// </summary>
        /// <param name="id">Id Element for Delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(string id)
        {
            var response = await _service.GetPositionByCondition(x => x.Id == id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            await _service.DeletePosition(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> PositionExists(Expression<Func<Position, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}