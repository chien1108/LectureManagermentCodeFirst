using AutoMapper;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.Position;
using LecturerManagement.Services.PositionService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionsController(LecturerManagementSystemDbContext context, IPositionService positionService, IMapper mapper)
        {
            _context = context;
            _positionService = positionService;
            _mapper = mapper;
        }

        // GET: api/Positions
        /// <summary>
        /// Get All Position
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetPositionDto>>>> GetPositions()
        {
            return Ok(await _positionService.GetAllPosition());
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
            var position = await _positionService.GetPositionByCondition(x => x.Id == id);

            if (position == null)
            {
                return NotFound(position);
            }

            return Ok(position);
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
            if (updatePosition == null || id == null)
            {
                return BadRequest();
            }
            if (!await PositionExists(id))
            {
                return NotFound();
            }
            return Ok(await _positionService.UpdatePosition(id, updatePosition));
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

            return Ok(await _positionService.AddPosition(newPosition));
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
            var position = await _positionService.GetPositionByCondition(x => x.Id == id);
            if (position == null)
            {
                return NotFound(position);
            }
            await _positionService.DeletePosition(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> PositionExists(string id)
        {
            return await _positionService.IsExisted(x => x.Id == id);
        }
    }
}
