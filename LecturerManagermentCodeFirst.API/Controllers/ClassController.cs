using LecturerManagermentCodeFirst.API.Services.ClassService;
using LecturerManagermentCodeFirst.DTO.DTOS.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var response = await _classService.GetClasses();
            if (response.Data == null)
            {
                response.Message = "no class found";
                response.Success = false;
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetClassByName(string name)
        {
            var response = await _classService.GetClassById(name);
            if (response.Data == null)
            {
                response.Message = "no class found";
                response.Success = false;
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClass(string name)
        {
            return Ok(await _classService.DeleteClass(name));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass(UpdateClassDto classUpdate)
        {
            var response = await _classService.UpdateClass(classUpdate);
            if (response.Success == false)
            {
                response.Message = "failed to update";
                response.Success = false;
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(AddClassDto classAdd)
        {
            var response = await _classService.AddClass(classAdd);
            if (response.Success == false)
            {
                response.Message = "Add failed";
                response.Success = false;
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
