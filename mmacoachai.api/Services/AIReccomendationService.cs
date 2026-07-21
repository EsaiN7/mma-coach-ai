using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmacoachai.api.Services;
using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using mmacoachai.core.Mappers;
using mmacoachai.infrastructure.Data;
using Microsoft.Extensions.Configuration;
using OpenAI;


namespace mmacoachai.api.Services
{
    public class AIReccomendationService
    {
        

        private readonly OpenAIClient _openAIClient;

        public AIReccomendationService(OpenAIClient client)
        {
            _openAIClient = client;
        }


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

                     Provide exactly three coaching recommendations.

                     Each recommendation should be one sentence.

                     Do not use markdown.

                     Do not include introductions or conclusions.

                     Focus on actionable MMA coaching advice.
                     """;
        }


        public async Task<string> GetReccomendationsAsync(AthleteProfileResponse athlete)
        {
            try
            {
                var chatClient = _openAIClient.GetChatClient("gpt-4.1-mini");

                var prompt = BuildPrompt(athlete);

                var completion = await chatClient.CompleteChatAsync(prompt);

                return completion.Value.Content[0].Text;
            }
            catch (Exception)
            {
                return """
                 AI service unavailable (demo mode).

                 Suggested coaching recommendations:
                 1. Increase defensive head movement drills.
                 2. Continue emphasizing Brazilian Jiu-Jitsu while improving boxing fundamentals.
                 3. Add one conditioning-focused session each week.
                 """;
            }
        }


    }
}
