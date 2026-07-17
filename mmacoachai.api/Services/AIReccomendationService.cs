using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmacoachai.api.Services;
using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;


namespace mmacoachai.api.Services
{
    public class AIReccomendationService
    {

        private string BuildPrompt(AthleteProfileResponse athlete)
        {
            return $"""
                     You are an experienced MMA coach.

                     Athlete:
                     Name: {athlete.FirstName} {athlete.LastName}

                     Coach:
                     {athlete.CoachName}

                     Highest Skill:
                     {athlete.HighestRatedSkill}

                     Lowest Skill:
                     {athlete.LowestRatedSkill}

                     Average Training Session:
                     {athlete.LengthOfAverageTrainingSession} minutes

                     Total Sessions:
                     {athlete.TotalTrainingSessions}

                     Provide three concise coaching recommendations.
                     """;
        }


        public async Task<string> GetReccomendatonsAsync(AthleteProfileResponse athlete)
        {
            var prompt = BuildPrompt(athlete);

            await Task.Delay(500);

            return $"Prompt sent to AI:\n\n{prompt}";
        }


    }
}
