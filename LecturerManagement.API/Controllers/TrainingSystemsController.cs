using AutoMapper;
using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.TrainingSystem;
using LecturerManagement.Services.TrainingSystemService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSystemsController : ControllerBase
    {
        private readonly ITrainingSystemService _trainingSystemService;
        private readonly IMapper _mapper;

        public TrainingSystemsController(ITrainingSystemService trainingSystemService, IMapper mapper)
        {
            _trainingSystemService = trainingSystemService;
            _mapper = mapper;
        }

        // GET: api/TrainingSystems
        /// <summary>
        /// Get All Training System
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTrainingSystems")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetTrainingSystemDto>>>> GetTrainingSystems()
        {
            return Ok(await _trainingSystemService.GetAllTrainingSystem());
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
            var trainingSystem = await _trainingSystemService.GetTrainingSystemByCondition(x => x.Id == id);

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
            if (!await TrainingSystemExists(id))
            {
                return NotFound();
            }

            return Ok(await _trainingSystemService.UpdateTrainingSystem(updatedTrainingSystem, expression: x => x.Id == id));
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
                return Ok(await _trainingSystemService.AddTrainingSystem(newTrainingSystem));
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
            var trainingSystem = await _trainingSystemService.GetTrainingSystemByCondition(x => x.Id == id);
            if (trainingSystem == null)
            {
                return NotFound(trainingSystem);
            }
            await _trainingSystemService.DeleteTrainingSystem(x => x.Id == id);
            return NoContent();
        }

        private async Task<bool> TrainingSystemExists(string id)
        {
            var response = await _trainingSystemService.IsExisted(x => x.Id == id);
            return response.Success;
        }
    }
}
