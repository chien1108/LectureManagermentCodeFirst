using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.LecturerScientificResearch;
using LecturerManagement.Services.LecturerScientificResearchService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerScientificResearchesController : ControllerBase
    {
        private readonly ILecturerScientificResearchService _service;

        public LecturerScientificResearchesController(ILecturerScientificResearchService service)
        {
            _service = service;
        }

        // GET: api/LecturerScientificResearches
        /// <summary>
        /// Get All LecturerScientificResearches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetLecturerScientificResearchDto>>> GetLecturerScientificResearches()
        {
            return Ok(await _service.GetAllLecturerScientificResearch());
        }

        // GET: api/LecturerScientificResearches/5
        /// <summary>
        /// Get Single LecturerScientificResearches by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetLecturerScientificResearchDto>>> GetLecturerScientificResearch(string id)
        {
            var response = await _service.GetLecturerScientificResearchByCondition(x => x.Id.ToLower().Equals(id.ToLower()));

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        // PUT: api/LecturerScientificResearches/5
        /// <summary>
        /// Update LecturerScientificResearches by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateLecturerScientificResearchDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetLecturerScientificResearchDto>>> PutLecturerScientificResearch(string id, UpdateLecturerScientificResearchDto updateLecturerScientificResearchDto)
        {
            if (updateLecturerScientificResearchDto == null)
            {
                return BadRequest();
            }
            if (!await LecturerScientificResearchExists(id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateLecturerScientificResearch(updateLecturerScientificResearchDto, x => x.Id == id));
        }

        // POST: api/LecturerScientificResearches
        /// <summary>
        /// Add New LecturerScientificResearches
        /// </summary>
        /// <param name="addLecturerScientificResearchDto"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete LecturerScientificResearches by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturerScientificResearch(string id)
        {
            var response = await _service.GetLecturerScientificResearchByCondition(x => x.Id == id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _service.DeleteLecturerScientificResearch(x => x.Id == id));
        }

        private async Task<bool> LecturerScientificResearchExists(string id)
        {
            return await _service.IsExisted(x => x.Id.ToLower().Equals(id.ToLower()));
        }
    }
}