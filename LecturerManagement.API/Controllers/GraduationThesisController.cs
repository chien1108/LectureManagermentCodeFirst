using AutoMapper;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.GraduationThesis;
using LecturerManagement.Services.GraduationThesisService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduationThesisController : ControllerBase
    {
        private readonly IGraduationThesisService _graduationThesisService;
        private readonly IMapper _mapper;

        public GraduationThesisController(IGraduationThesisService graduationThesisService, IMapper mapper)
        {
            _graduationThesisService = graduationThesisService;
            _mapper = mapper;
        }

        // GET: api/GraduationThesis
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GraduationThesis>>>> GetGraduationTheses()
        {
            return Ok(await _graduationThesisService.GetAllGraduationThesis());
        }

        // GET: api/GraduationThesis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GraduationThesis>> GetGraduationThesis(int id)
        {
            var graduationThesis = await _graduationThesisService.GetGraduationThesisByCondition(x => x.Id == id);

            if (graduationThesis.Data == null)
            {
                return NotFound(graduationThesis);
            }

            return Ok(graduationThesis);
        }

        // PUT: api/GraduationThesis/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="graduationThesis"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetGraduationThesisDto>>> UpdateGraduationThesis(int id, UpdateGraduationThesisDto graduationThesis)
        {
            ////if (id != graduationThesis.Id)
            ////{
            ////    return BadRequest();
            ////}
            if (!await GraduationThesisExists(id))
            {
                return NotFound();
            }
            return Ok(await _graduationThesisService.UpdateGraduationThesis(graduationThesis));
        }

        // POST: api/GraduationThesis
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graduationThesis"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GraduationThesis>> AddGraduationThesis(AddGraduationThesisDto graduationThesis)
        {
            return Ok(await _graduationThesisService.AddGraduationThesis(graduationThesis));
        }

        // DELETE: api/GraduationThesis/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduationThesis(int id)
        {
            var @response = await _graduationThesisService.GetGraduationThesisByCondition(x => x.Id == id);
            if (@response.Data == null)
            {
                return NotFound(@response);
            }
            return Ok(_graduationThesisService.DeleteGraduationThesis(_mapper.Map<GraduationThesis>(@response.Data)));
        }

        private async Task<bool> GraduationThesisExists(int id)
        {
            return await _graduationThesisService.IsExisted(x => x.Id == id);
        }
    }
}
