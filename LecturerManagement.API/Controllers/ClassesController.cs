using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.Class;
using LecturerManagement.Services.ClassService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassesController(IClassService service)
        {
            _service = service;
        }

        // GET: api/Classes
        /// <summary>
        /// Get All Class
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetClasses")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetClassDto>>>> GetClasses()
        {
            return Ok(await _service.GetAllClass());
        }

        // GET: api/Classes/5
        /// <summary>
        /// Get Class By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetClass")]
        public async Task<ActionResult<ServiceResponse<GetClassDto>>> GetClass(string id)
        {
            return Ok(await _service.GetClassByCondition(x => x.Id == id));
        }

        // PUT: api/Classes/5
        /// <summary>
        /// Update Class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateClass"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(string id, UpdateClassDto updateClass)
        {
            if (!await ClassExists(id))
            {
                return NotFound();
            }

            return Ok(await _service.UpdateClass(updateClass));
        }

        // POST: api/Classes
        /// <summary>
        /// Add New Class
        /// </summary>
        /// <param name="newClass"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetClassDto>>> AddNewClass(AddClassDto newClass)
        {
            return Ok(await _service.AddNewClass(newClass));
        }

        // DELETE: api/Classes/5
        /// <summary>
        /// Delete Class By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClassDto>>> DeleteClass(string id)
        {
            var response = await _service.GetClassByCondition(x => x.Id == id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _service.DeleteClass(x => x.Id == id));
        }

        private async Task<bool> ClassExists(string id)
        {
            return await _service.IsExisted(x => x.Id == id);
        }
    }
}