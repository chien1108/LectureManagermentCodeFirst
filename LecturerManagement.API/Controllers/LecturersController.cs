using AutoMapper;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.Services.LecturerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;
        private readonly IMapper _mapper;

        public LecturersController( ILecturerService lecturerService, IMapper mapper)
        {
            _lecturerService = lecturerService;
            _mapper = mapper;
        }

        // GET: api/Lecturers
        [HttpGet]
        public async Task<IActionResult> GetLecturers()
        {
            var response = await _lecturerService.GetAllLecturer();
            if(response.Data == null)
            {
                return NotFound(response);
            }    
            return Ok(response);
        }

        // GET: api/Lecturers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturer(string id)
        {
            var lecturer = await _lecturerService.GetLecturerByCondition(x => x.Id.ToLower().Equals(id.ToLower()));

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
            if(!await LecturerExists(id))
            {
                return NotFound();
            }
            return Ok(await _lecturerService.UpdateLecturer(updateLecturerDto));
        }

        // POST: api/Lecturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lecturer>> PostLecturer(AddLecturerDto addLecturerDto)
        {
            var response = await _lecturerService.AddLecturer(addLecturerDto);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // DELETE: api/Lecturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer(string id)
        {
            var data = _mapper.Map<Lecturer>(await _lecturerService.GetLecturerByCondition(x => x.Id.ToLower().Equals(id.ToLower())));
            var response = await _lecturerService.DeleteLecturer(data);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        private async Task<bool> LecturerExists(string id)
        {
            return await _lecturerService.IsExisted(x => x.Id.ToLower().Equals(id.ToLower()));
        }
    }
}
