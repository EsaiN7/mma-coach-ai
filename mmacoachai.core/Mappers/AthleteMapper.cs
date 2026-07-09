using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace mmacoachai.core.Mappers
{
    public static class AthleteMapper
    {
       public static AthleteResponse ToAthleteResponse(Athlete athlete)
        {
            return new AthleteResponse
            {
                Id = athlete.Id,
                CoachId = athlete.CoachId,
                FirstName = athlete.FirstName,
                LastName = athlete.LastName,
                NickName = athlete.NickName,
                Age = athlete.Age,
                WeightLbs = athlete.WeightLbs,
                Stance = athlete.Stance,
                ExperienceYears = athlete.ExperienceYears,
                CoachNotes = athlete.CoachNotes
            };
        }
    }
}
