using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;

namespace mmacoachai.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingSessionControlller : ControllerBase
    {
        private readonly AppDbContext _context;
        public TrainingSessionControlller(AppDbContext context)
        {
            _context = context;
        }

        //get all training sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingSessionResponse>>> GetTrainingSessions()
        {
            var trainingSessions = await _context.TrainingSessions.ToListAsync();
            var response = trainingSessions.Select(TrainingSessionMapper.ToTrainingSessionResponse);
            return Ok(response);
        }
        //get training session by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TrainingSessionResponse>> GetTrainingSession(int id)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null)
            {
                return NotFound();
            }
            return Ok(TrainingSessionMapper.ToTrainingSessionResponse(trainingSession));
        }
        //create a new training session
        [HttpPost]
        public async Task<ActionResult<TrainingSessionResponse>> CreateTrainingSession(CreateTrainingSessionRequest request)
        {
            var trainingSession = new TrainingSession
            {
                AthleteId = request.AthleteId,
                Date = request.Date,
                DurationMinutes = request.DurationMinutes,
                Notes = request.Notes
            };
            _context.TrainingSessions.Add(trainingSession);
            await _context.SaveChangesAsync();
            return Ok(TrainingSessionMapper.ToTrainingSessionResponse(trainingSession));
        }
        //update training session by id
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TrainingSessionResponse>> UpdateTrainingSession(int id, UpdateTrainingSessionRequest request)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null)
            {
                return NotFound();
            }
            trainingSession.Date = request.Date;
            trainingSession.DurationMinutes = request.DurationMinutes;
            trainingSession.Notes = request.Notes;
            await _context.SaveChangesAsync();
            return Ok(TrainingSessionMapper.ToTrainingSessionResponse(trainingSession));
        }

        //delete training session by id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTrainingSession(int id)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null)
            {
                return NotFound();
            }
            _context.TrainingSessions.Remove(trainingSession);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
