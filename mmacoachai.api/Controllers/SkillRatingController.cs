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
    public class SkillRatingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SkillRatingController(AppDbContext context)
        {
            _context = context;
        }
        //Get all skill ratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillRatingResponse>>> GetSkillRatings()
        {
            var skillRatings = await _context.SkillRatings.ToListAsync();
            var response = skillRatings.Select(SkillRatingMapper.ToSkillRatingResponse);
            return Ok(response);
        }
        //Get skill rating by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SkillRatingResponse>> GetSkillRating(int id)
        {
            var skillRating = await _context.SkillRatings.FindAsync(id);
            if (skillRating == null)
            {
                return NotFound();
            }
            return Ok(SkillRatingMapper.ToSkillRatingResponse(skillRating));
        }
        //create a skill rating
        [HttpPost]
        public async Task<ActionResult<SkillRatingResponse>> CreateSkillRating(CreateSkillRatingRequest request)
        {
            var skillRating = new SkillRating
            {
                AthleteId = request.AthleteId,
                SkillName = request.SkillName,
                Rating = request.Rating
            };
            _context.SkillRatings.Add(skillRating);
            await _context.SaveChangesAsync();
            return Ok(SkillRatingMapper.ToSkillRatingResponse(skillRating));
        }
        //update a skill rating by id
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSkillRating(int id, UpdateSkillRatingRequest request)
        {
            var skillRating = await _context.SkillRatings.FindAsync(id);
            if (skillRating == null)
            {
                return NotFound();
            }
            skillRating.SkillName = request.SkillName;
            skillRating.Rating = request.Rating;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //delete a skill rating by id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSkillRating(int id)
        {
            var skillRating = await _context.SkillRatings.FindAsync(id);
            if (skillRating == null)
            {
                return NotFound();
            }
            _context.SkillRatings.Remove(skillRating);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
