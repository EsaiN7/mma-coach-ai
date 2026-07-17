using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class AthleteProfileResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Nickname { get; set; } = "";

        public string CoachName { get; set; } = "";

        public List<SkillRatingResponse> SkillRatings { get; set; } = [];

        public List<TrainingSessionResponse> TrainingSessions { get; set; } = [];

        //Computed Properties
        public int TotalTrainingSessions { get; set; }
        public double LengthOfAverageTrainingSession { get; set; }
        public string HighestRatedSkill { get; set; } = "";
        public string LowestRatedSkill { get; set; } = "";
    }
}
