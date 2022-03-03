using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.Services.LecturerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerService _service;

        public LecturersController(ILecturerService lecturerService)
        {
            _service = lecturerService;
        }

        // GET: api/Lecturers
        /// <summary>
        /// Get All Lecturer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetLecturerDto>>>> GetLecturers()
        {
            return Ok(await _service.GetAllLecturer());
        }

        // GET: api/Lecturers/5
        /// <summary>
        /// Get Lecturer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturer(string id)
        {
            var lecturer = await _service.GetLecturerByCondition(x => x.Id.ToLower().Equals(id.ToLower()));

            if (lecturer.Data == null)
            {
                return NotFound(lecturer);
            }

            return Ok(lecturer);
        }

        // PUT: api/Lecturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutLecturer(string id, UpdateLecturerDto updateLecturerDto)
        {
            if (updateLecturerDto == null)
            {
                return BadRequest();
            }
            if (!await LecturerExists(id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateLecturer(updateLecturerDto, x => x.Id == id));
        }

        // POST: api/Lecturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lecturer>> PostLecturer(AddLecturerDto addLecturerDto)
        {
            var response = await _service.AddLecturer(addLecturerDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // DELETE: api/Lecturers/5
        /// <summary>
        /// Delete Lecturer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer(string id)
        {
            var response = await _service.GetLecturerByCondition(x => x.Id == id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _service.DeleteLecturer(x => x.Id == id));
        }

        private async Task<bool> LecturerExists(string id)
        {
            return await _service.IsExisted(x => x.Id.ToLower().Equals(id.ToLower()));
        }
    }
}
