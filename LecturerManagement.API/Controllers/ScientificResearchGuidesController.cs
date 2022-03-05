using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.ScientificResearchGuide;
using LecturerManagement.Services.ScientificResearchGuideService;
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
    public class ScientificResearchGuidesController : ControllerBase
    {
        private readonly IScientificResearchGuideService _service;

        public ScientificResearchGuidesController(IScientificResearchGuideService service)
        {
            _service = service;
        }

        // GET: api/ScientificResearchGuides
        /// <summary>
        /// Get All ScientificResearchGuides
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetScientificResearchGuideDto>>>> GetScientificResearchGuides()
        {
            return Ok(await _service.GetAllScientificResearchGuide());
        }

        // GET: api/ScientificResearchGuides/5
        /// <summary>
        /// Get Scientific Research Guides By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetScientificResearchGuideDto>>> GetScientificResearchGuide(string id)
        {
            var response = await _service.GetScientificResearchGuideByCondition(x => x.Id == id);

            if (response.Data == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // PUT: api/ScientificResearchGuides/5
        /// <summary>
        /// Update Scientific Research Guides By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scientificResearchGuide"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetScientificResearchGuideDto>>> UpdateScientificResearchGuide(string id, UpdateScientificResearchGuideDto scientificResearchGuide)
        {
            if (scientificResearchGuide == null)
            {
                return BadRequest();
            }
            if (!await ScientificResearchGuideExists(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateScientificResearchGuide(scientificResearchGuide, x => x.Id == id));
        }

        // POST: api/ScientificResearchGuides
        /// <summary>
        /// Add New Scientific Research Guides
        /// </summary>
        /// <param name="scientificResearchGuide"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetScientificResearchGuideDto>>> AddScientificResearchGuide(AddScientificResearchGuideDto scientificResearchGuide)
        {
            if (scientificResearchGuide == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _service.AddScientificResearchGuide(scientificResearchGuide));
            }
        }

        // DELETE: api/ScientificResearchGuides/5
        /// <summary>
        /// Delete Scientific Research Guide By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScientificResearchGuide(string id)
        {
            if (!await ScientificResearchGuideExists(x => x.Id == id))
            {
                return NotFound();
            }
            await _service.DeleteScientificResearchGuide(x => x.Id == id);

            return NoContent();
        }

        private async Task<bool> ScientificResearchGuideExists(Expression<Func<ScientificResearchGuide, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}