using AutoMapper;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Services.MachineRoomService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineRoomsController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;
        private readonly IMachineRoomService _machineRoomService;
        private readonly IMapper _mapper;

        public MachineRoomsController(LecturerManagementSystemDbContext context, IMachineRoomService machineRoomService, IMapper mapper)
        {
            _context = context;
            _machineRoomService = machineRoomService;
            _mapper = mapper;
        }

        // GET: api/MachineRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineRoom>>> GetMachineRooms()
        {
            return await _context.MachineRooms.ToListAsync();
        }

        // GET: api/MachineRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineRoom>> GetMachineRoom(string id)
        {
            var machineRoom = await _context.MachineRooms.FindAsync(id);

            if (machineRoom == null)
            {
                return NotFound();
            }

            return machineRoom;
        }

        // PUT: api/MachineRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachineRoom(string id, MachineRoom machineRoom)
        {
            if (id != machineRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(machineRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MachineRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MachineRoom>> PostMachineRoom(MachineRoom machineRoom)
        {
            _context.MachineRooms.Add(machineRoom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MachineRoomExists(machineRoom.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMachineRoom", new { id = machineRoom.Id }, machineRoom);
        }

        // DELETE: api/MachineRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachineRoom(string id)
        {
            var machineRoom = await _context.MachineRooms.FindAsync(id);
            if (machineRoom == null)
            {
                return NotFound();
            }

            _context.MachineRooms.Remove(machineRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MachineRoomExists(string id)
        {
            return _context.MachineRooms.Any(e => e.Id == id);
        }
    }
}
