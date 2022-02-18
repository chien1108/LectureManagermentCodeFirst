using AutoMapper;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.AdvancedLearning;
using LecturerManagement.Services.AdvancedLearningService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedLearningsController : ControllerBase
    {
        private readonly IAdvancedLearningService _service;
        private readonly IMapper _mapper;

        public AdvancedLearningsController(IAdvancedLearningService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/AdvancedLearnings
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<ICollection<GetAdvancedLearningDto>>>> GetListAdvancedLearning()
        {
            return Ok(await _service.GetAllAdvancedLearning());
        }

        // GET: api/AdvancedLearnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdvancedLearningDto>>> GetAdvancedLearning(int id)
        {
            return Ok(await _service.GetAdvancedLearningByCondition(x => x.Id == id));
        }

        // PUT: api/AdvancedLearnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdvancedLearningDto>>> UpdateAdvancedLearning(UpdateAdvancedLearningDto updateAdvancedLearning)
        {
            var response = await _service.UpdateAdvancedLearning(updateAdvancedLearning);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // POST: api/AdvancedLearnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAdvancedLearningDto>>>> AddAdvancedLearning(AddAdvancedLearningDto newAdvancedLearning)
        {
            return Ok(await _service.AddAdvancedLearning(newAdvancedLearning));
        }

        // DELETE: api/AdvancedLearnings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdvancedLearningDto>>> DeleteAdvancedLearning(int id)
        {
            var data = _mapper.Map<AdvancedLearning>(await _service.GetAdvancedLearningByCondition(x => x.Id == id));
            var response = await _service.DeleteAdvancedLearning(data);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        ////private async Task<ActionResult<ServiceResponse<AdvancedLearning>>> AdvancedLearningExists(int id)
        ////{
        ////    var response = await _service.IsExisted(x => x.Id == id);

        ////    if (response.Data != null)
        ////    {
        ////        return Ok(response);
        ////    }
        ////    else
        ////    {
        ////        return BadRequest(response);
        ////    }
        ////}
    }
}
