using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;

namespace mmacoachai.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthletesController : ControllerBase
{
    private readonly AppDbContext _context;

    public AthletesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AthleteResponse>>> GetAthletes()
    {
        var athletes = await _context.Athletes.ToListAsync();

        var response = athletes.Select(AthleteMapper.ToAthleteResponse);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<AthleteResponse>> CreateAthlete(CreateAthleteRequest request)
    {
        var athlete = new Athlete
        {
            CoachId = request.CoachId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            NickName = request.NickName,
            Age = request.Age,
            WeightLbs = request.WeightLbs,
            Stance = request.Stance,
            ExperienceYears = request.ExperienceYears,
            CoachNotes = request.CoachNotes
        };

        _context.Athletes.Add(athlete);
        await _context.SaveChangesAsync();

        return Ok(AthleteMapper.ToAthleteResponse(athlete));
    }
}