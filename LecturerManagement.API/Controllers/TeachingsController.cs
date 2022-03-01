using AutoMapper;
using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.Teaching;
using LecturerManagement.Services.TeachingService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingsController : ControllerBase
    {
        private readonly ITeachingService _teachingService;
        private readonly IMapper _mapper;

        public TeachingsController(ITeachingService teachingService, IMapper mapper)
        {
            _teachingService = teachingService;
            _mapper = mapper;
        }

        // GET: api/Teachings
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetTeachingDto>>>> GetTeachings()
        {
            return Ok(await _teachingService.GetAllTeaching());
        }

        // GET: api/Teachings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTeachingDto>>> GetTeaching(string id)
        {
            var teaching = await _teachingService.GetTeachingByCondition(x => x.Id == id);

            if (teaching == null)
            {
                return NotFound();
            }

            return Ok(teaching);
        }

        // PUT: api/Teachings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTeachingDto>>> UpdateTeaching(string id, UpdateTeachingDto teaching)
        {
            if (teaching == null)
            {
                return BadRequest();
            }
            if (!await TeachingExists(id))
            {
                return NotFound();
            }
            return Ok(await _teachingService.UpdateTeaching(teaching, x => x.Id == id));
        }

        // POST: api/Teachings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetTeachingDto>>> AddTeaching(AddTeachingDto teaching)
        {
            if (teaching == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _teachingService.AddTeaching(teaching));
            }
        }

        // DELETE: api/Teachings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeaching(string id)
        {

            if (!await TeachingExists(id))
            {
                return NotFound();
            }
            await _teachingService.DeleteTeaching(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> TeachingExists(string id)
        {
            return await _teachingService.IsExisted(x => x.Id == id);
        }
    }
}
