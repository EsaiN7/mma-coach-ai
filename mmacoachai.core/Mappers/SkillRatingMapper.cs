using mmacoachai.core.DTOs;
using mmacoachai.core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
namespace mmacoachai.core.Mappers
{
    public static class SkillRatingMapper
    {
        public static SkillRatingResponse ToSkillRatingResponse(SkillRating skillRating)
        {
            return new SkillRatingResponse
            {
                Id = skillRating.Id,
                AthleteId = skillRating.AthleteId,
                SkillName = skillRating.SkillName,
                Rating = skillRating.Rating
            };
        }
    }
}
