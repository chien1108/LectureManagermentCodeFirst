using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.TrainingSystem;
using LecturerManagement.Services.TrainingSystemService;
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
    public class TrainingSystemsController : ControllerBase
    {
        private readonly ITrainingSystemService _service;

        public TrainingSystemsController(ITrainingSystemService trainingSystemService)
        {
            _service = trainingSystemService;
        }

        // GET: api/TrainingSystems
        /// <summary>
        /// Get All Training System
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrainingSystems")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetTrainingSystemDto>>>> GetTrainingSystems()
        {
            return Ok(await _service.GetAllTrainingSystem());
        }

        // GET: api/TrainingSystems/5
        /// <summary>
        /// Get Single Training System
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTrainingSystemDto>>> GetTrainingSystem(string id)
        {
            var trainingSystem = await _service.GetTrainingSystemByCondition(x => x.Id.ToLower().Trim() == id.ToLower().Trim());

            if (trainingSystem.Data == null)
            {
                return NotFound(trainingSystem);
            }

            return Ok(trainingSystem);
        }

        // PUT: api/TrainingSystems/5
        /// <summary>
        /// Update Training System By Id
        /// </summary>
        /// <param name="id">Id For update element</param>
        /// <param name="updatedTrainingSystem">Update Object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTrainingSystemDto>>> UpdateTrainingSystem(string id, UpdateTrainingSystemDto updatedTrainingSystem)
        {
            if (updatedTrainingSystem == null)
            {
                return BadRequest();
            }
            if (!await TrainingSystemExists(x => x.Id.ToLower().Trim() == id.ToLower().Trim()))
            {
                return NotFound();
            }

            return Ok(await _service.UpdateTrainingSystem(updatedTrainingSystem, expression: x => x.Id.ToLower().Trim() == id.ToLower().Trim()));
        }

        // POST: api/TrainingSystems
        /// <summary>
        /// Add New Training System(Thêm Mới Hệ Đào Tạo)
        /// </summary>
        /// <param name="newTrainingSystem">New Object Instance for Add</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetTrainingSystemDto>>> AddNewTrainingSystem(AddTrainingSystemDto newTrainingSystem)
        {

            if (newTrainingSystem == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _service.AddTrainingSystem(newTrainingSystem));
            }

        }

        // DELETE: api/TrainingSystems/5
        /// <summary>
        /// Delete Training System By Id(Xoá hệ đào tạo theo ID)
        /// </summary>
        /// <param name="id">Id For Delete Tranining System</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSystem(string id)
        {
            if (!await TrainingSystemExists(x => x.Id.ToLower().Trim() == id.ToLower().Trim()))
            {
                return NotFound();
            }
            await _service.DeleteTrainingSystem(x => x.Id.ToLower().Trim() == id.ToLower().Trim());
            return NoContent();
        }

        private async Task<bool> TrainingSystemExists(Expression<Func<TrainingSystem, bool>> expression = null)
        {
            return await _service.IsExisted(expression);
        }
    }
}
