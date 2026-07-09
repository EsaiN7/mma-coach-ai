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
    public class CoachesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CoachesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachResponse>>> GetCoaches()
        {
            var coaches = await _context.Coaches.ToListAsync();

            var response = coaches.Select(CoachMapper.ToCoachResponse);

            return Ok(response);
        }
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
    }
 
}
