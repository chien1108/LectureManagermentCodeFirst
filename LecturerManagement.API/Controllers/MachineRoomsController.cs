using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.MachineRoom;
using LecturerManagement.Services.MachineRoomService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineRoomsController : ControllerBase
    {
        private readonly IMachineRoomService _service;
        public MachineRoomsController(IMachineRoomService machineRoomService)
        {
            _service = machineRoomService;
        }

        // GET: api/MachineRooms
        /// <summary>
        /// Get All Machine Room
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetMachineRoomDto>>>> GetMachineRooms()
        {
            return Ok(await _service.GetAllMachineRoom());
        }

        // GET: api/MachineRooms/5
        /// <summary>
        /// Get Machine Room By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMachineRoomDto>>> GetMachineRoom(string id)
        {
            var response = await _service.GetMachineRoomByCondition(x => x.Id == id);

            if (response.Data == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // PUT: api/MachineRooms/5
        /// <summary>
        /// Update Machine Room By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="machineRoom"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachineRoom(string id, UpdateMachineRoomDto machineRoom)
        {
            if (machineRoom == null)
            {
                return BadRequest();
            }
            if (!await MachineRoomExists(id))
            {
                return NotFound();
            }
            return Ok(await _service.UpdateMachineRoom(machineRoom, x => x.Id == id));
        }

        // POST: api/MachineRooms
        /// <summary>
        /// Add New Machine Room
        /// </summary>
        /// <param name="machineRoom"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetMachineRoomDto>>> AddMachineRoom(AddMachineRoomDto machineRoom)
        {
            if (machineRoom == null)
            {
                return BadRequest();
            }

            return Ok(await _service.AddMachineRoom(machineRoom));
        }

        // DELETE: api/MachineRooms/5
        /// <summary>
        /// Delete Machine Room By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMachineRoomDto>>> DeleteMachineRoom(string id)
        {
            var response = await _service.GetMachineRoomByCondition(x => x.Id == id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _service.DeleteMachineRoom(x => x.Id == id));
        }

        private async Task<bool> MachineRoomExists(string id)
        {
            return await _service.IsExisted(x => x.Id == id);
        }
    }
}
