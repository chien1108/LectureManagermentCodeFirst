using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSystemsController : ControllerBase
    {
        private readonly LecturerManagementSystemDbContext _context;

        public TrainingSystemsController(LecturerManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingSystems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingSystem>>> GetTrainingSystems()
        {
            return await _context.TrainingSystems.ToListAsync();
        }

        // GET: api/TrainingSystems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingSystem>> GetTrainingSystem(string id)
        {
            var trainingSystem = await _context.TrainingSystems.FindAsync(id);

            if (trainingSystem == null)
            {
                return NotFound();
            }

            return trainingSystem;
        }

        // PUT: api/TrainingSystems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingSystem(string id, TrainingSystem trainingSystem)
        {
            if (id != trainingSystem.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingSystem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingSystemExists(id))
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

        // POST: api/TrainingSystems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingSystem>> PostTrainingSystem(TrainingSystem trainingSystem)
        {
            _context.TrainingSystems.Add(trainingSystem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingSystemExists(trainingSystem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainingSystem", new { id = trainingSystem.Id }, trainingSystem);
        }

        // DELETE: api/TrainingSystems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSystem(string id)
        {
            var trainingSystem = await _context.TrainingSystems.FindAsync(id);
            if (trainingSystem == null)
            {
                return NotFound();
            }

            _context.TrainingSystems.Remove(trainingSystem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingSystemExists(string id)
        {
            return _context.TrainingSystems.Any(e => e.Id == id);
        }
    }
}
