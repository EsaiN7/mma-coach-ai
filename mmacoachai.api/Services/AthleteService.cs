using Microsoft.EntityFrameworkCore;
using mmacoachai.core.DTOs;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;

namespace mmacoachai.api.Services
{
    public class AthleteService
    {
        private readonly AppDbContext _context;

        public AthleteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AthleteProfileResponse?> GetAthleteProfileAsync(int id)
        {
            var athlete = await _context.Athletes
                .Include(a => a.Coach)
                .Include(a => a.SkillRatings)
                .Include(a => a.TrainingSessions)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (athlete == null)
            {
                return null;
            }

            return new AthleteProfileResponse
            {
                Id = athlete.Id,
                FirstName = athlete.FirstName,
                LastName = athlete.LastName,
                Nickname = athlete.NickName,

                CoachName = athlete.Coach?.Name ?? "",

                SkillRatings = athlete.SkillRatings
                    .Select(SkillRatingMapper.ToSkillRatingResponse)
                    .ToList(),

                TrainingSessions = athlete.TrainingSessions
                    .Select(TrainingSessionMapper.ToTrainingSessionResponse)
                    .ToList(),

                TotalTrainingSessions = athlete.TrainingSessions.Count,

                LengthOfAverageTrainingSession = athlete.TrainingSessions.Any()
                 ? athlete.TrainingSessions.Average(ts => ts.DurationMinutes)
                 : 0,

                HighestRatedSkill = athlete.SkillRatings.Any()
                 ? athlete.SkillRatings.OrderByDescending(sr => sr.Rating).First().SkillName
                 : "",

                LowestRatedSkill = athlete.SkillRatings.Any()
                 ? athlete.SkillRatings.OrderBy(sr => sr.Rating).First().SkillName
                 : ""

            };
        }
    }
}