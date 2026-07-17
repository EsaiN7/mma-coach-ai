using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmacoachai.api.Services;
using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;

namespace mmacoachai.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoachesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CoachService _coachService;

        public CoachesController(AppDbContext context, CoachService coachService)
        {
            _context = context;
            _coachService = coachService;
        }

        //Get Coach Dashboard by id
        [HttpGet("{id}/dashboard")]
        public async Task<ActionResult<CoachDashboardResponse>> GetDashBoard(int id)
        {
            var dashboard = await _coachService.GetCoachDashboardResponseAsync(id);

            if (dashboard == null)
            {
                return NotFound();
            }

            return Ok(dashboard);
        }

        //Get all coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachResponse>>> GetCoaches()
        {
            var coaches = await _context.Coaches.ToListAsync();

            var response = coaches.Select(CoachMapper.ToCoachResponse);

            return Ok(response);
        }

        //Get coach by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CoachResponse>> GetCoach(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return Ok(CoachMapper.ToCoachResponse(coach));
        }

        //used for inserting a new coach into the database
        [HttpPost]
        public async Task<ActionResult<CoachResponse>> CreateCoach(CreateCoachRequest request)
        {
            var coach = new Coach
            {
                Name = request.Name,
                Email = request.Email
            };
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
            return Ok(CoachMapper.ToCoachResponse(coach));
        }

        //update coach by id
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CoachResponse>> UpdateCoach(int id, UpdateCoachRequest request)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            coach.Name = request.Name;
            coach.Email = request.Email;
            await _context.SaveChangesAsync();
            return Ok(CoachMapper.ToCoachResponse(coach));
        }


    }

}
