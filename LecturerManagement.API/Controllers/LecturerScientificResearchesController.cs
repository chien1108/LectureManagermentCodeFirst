using AutoMapper;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerScientificResearch;
using LecturerManagement.Services.LecturerScientificResearchService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerScientificResearchesController : ControllerBase
    {
        private readonly ILecturerScientificResearchService _service;
        private readonly IMapper _mapper;

        public LecturerScientificResearchesController(ILecturerScientificResearchService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/LecturerScientificResearches
        [HttpGet]
        public async Task<IActionResult> GetLecturerScientificResearches()
        {
            var response = await _service.GetAllLecturerScientificResearch();
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // GET: api/LecturerScientificResearches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturerScientificResearch(string id)
        {
            var lecturerScientificResearch = await _service.GetLecturerScientificResearchByCondition(x => x.Id.ToLower().Equals(id.ToLower()));

            if (lecturerScientificResearch.Data == null)
            {
                return NotFound(lecturerScientificResearch);
            }
            return Ok(lecturerScientificResearch);
        }

        // PUT: api/LecturerScientificResearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutLecturerScientificResearch(string id, UpdateLecturerScientificResearchDto updateLecturerScientificResearchDto)
        {
            if (!await LecturerScientificResearchExists(id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateLecturerScientificResearch(updateLecturerScientificResearchDto));
        }

        // POST: api/LecturerScientificResearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostLecturerScientificResearch(AddLecturerScientificResearchDto addLecturerScientificResearchDto)
        {
            var response = await _service.AddLecturerScientificResearch(addLecturerScientificResearchDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // DELETE: api/LecturerScientificResearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturerScientificResearch(string id)
        {
            var data = _mapper.Map<LecturerScientificResearch>(await _service.GetLecturerScientificResearchByCondition(x => x.Id.ToLower().Equals(id.ToLower())));
            var response = await _service.DeleteLecturerScientificResearch(data);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        private async Task<bool> LecturerScientificResearchExists(string id)
        {
            return await _service.IsExisted(x => x.Id.ToLower().Equals(id.ToLower()));
        }
    }
}
