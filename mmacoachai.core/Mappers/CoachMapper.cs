using mmacoachai.core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.Mappers
{
    public static class CoachMapper
    {
        public static CoachResponse ToCoachResponse(Entities.Coach coach)
        {
            return new CoachResponse
            {
                Id = coach.Id,
                Name = coach.Name,
                Email = coach.Email
            };
        }
    }
}
