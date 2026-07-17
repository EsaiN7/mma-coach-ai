using Microsoft.EntityFrameworkCore;
using mmacoachai.core.DTOs;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;


namespace mmacoachai.api.Services
{
    public class CoachService
    {
        private readonly AppDbContext _context;

        public CoachService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CoachDashboardResponse> GetCoachDashboardResponseAsync(int coachId)
        {
            var coach = await _context.Coaches
                .Include(c => c.Athletes)
                    .ThenInclude(a => a.SkillRatings)
                .Include(c => c.Athletes)
                    .ThenInclude(a => a.TrainingSessions)
                .FirstOrDefaultAsync(c => c.Id == coachId);


            return new CoachDashboardResponse
            {
                CoachId = coachId,
                CoachName = coach?.Name ?? "",
                AthleteCount = coach?.Athletes.Count ?? 0,
                AverageAthleteAge = coach?.Athletes.Any() == true
                    ? coach.Athletes.Average(a => a.Age)
                    : 0,
                AverageAthleteWeight = coach?.Athletes.Any() == true
                    ? coach.Athletes.Average(a => a.WeightLbs)
                    : 0,
                AverageExperienceYears = coach?.Athletes.Any() == true
                    ? coach.Athletes.Average(a => a.ExperienceYears)
                    : 0,
                TotalTrainingSessions = coach?.Athletes.Any() == true
                    ? coach.Athletes.Sum(a => a.TrainingSessions.Count)
                    : 0,
                AverageTrainingSessionLength = coach?.Athletes.Any() == true && coach.Athletes.Sum(a => a.TrainingSessions.Count) > 0
                    ? coach.Athletes.Sum(a => a.TrainingSessions.Sum(ts => ts.DurationMinutes)) / (double)coach.Athletes.Sum(a => a.TrainingSessions.Count)
                    : 0
            };
        }


    }
}
