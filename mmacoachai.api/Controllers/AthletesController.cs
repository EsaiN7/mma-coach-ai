using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmacoachai.api.Services;
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
    private readonly AthleteService _athleteService;
    private readonly AIReccomendationService _aiReccomendationService;

    public AthletesController(
     AppDbContext context,
     AthleteService athleteService,
     AIReccomendationService aiReccomendationService)
    {
        _context = context;
        _athleteService = athleteService;
        _aiReccomendationService = aiReccomendationService;
    }


    //get athlete profile by id
    [HttpGet("{id}/profile")]
    public async Task<ActionResult<AthleteProfileResponse>> GetProfile(int id)
    {
        var profile = await _athleteService.GetAthleteProfileAsync(id);

        if (profile == null)
        {
            return NotFound();
        }

        return Ok(profile);
    }

    //Get AI reccomendations for athlete by id
    [HttpGet("{id}/recommendations")]
    public async Task<ActionResult<string>> GetRecommendations(int id)
    {
        var profile = await _athleteService.GetAthleteProfileAsync(id);

        if (profile == null)
            return NotFound();

        var recommendations =
            await _aiReccomendationService.GetReccomendatonsAsync(profile);

        return Ok(recommendations);
    }

    //Get all athletes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AthleteResponse>>> GetAthletes()
    {
        var athletes = await _context.Athletes.ToListAsync();

        var response = athletes.Select(AthleteMapper.ToAthleteResponse);

        return Ok(response);
    }
    //Get athlete by id
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AthleteResponse>> GetAthlete(int id)
    {
        var athlete = await _context.Athletes.FindAsync(id);
        if (athlete == null)
        {
            return NotFound();
        }
        return Ok(AthleteMapper.ToAthleteResponse(athlete));
    }

    //used for inserting a new athlete into the database
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

    //update an athlete
    [HttpPut("{id:int}")]
    public async Task<ActionResult<AthleteResponse>> UpdateAthlete(int id, UpdateAthleteRequest request)
    {
        var athlete = await _context.Athletes.FindAsync(id);
        if (athlete == null)
        {
            return NotFound();
        }
        
        athlete.Age = request.Age;
        athlete.WeightLbs = request.WeightLbs;
        athlete.Stance = request.Stance;
        athlete.ExperienceYears = request.ExperienceYears;
        athlete.CoachNotes = request.CoachNotes;
        await _context.SaveChangesAsync();
        return Ok(AthleteMapper.ToAthleteResponse(athlete));
    }

    //delete an athlete
    [HttpDelete("{id:int}")]
    public ActionResult DeleteAthlete(int id)
    {
        var athlete = _context.Athletes.Find(id);
        if (athlete == null)
        {
            return NotFound();
        }
        _context.Athletes.Remove(athlete);
        _context.SaveChanges();
        return NoContent();
    }

}