using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class CoachDashboardResponse
    {
        public int CoachId { get; set; }

        public string CoachName { get; set; } = "";

        public int AthleteCount { get; set; }

        public double AverageAthleteAge { get; set; }

        public decimal AverageAthleteWeight { get; set; }

        public double AverageExperienceYears { get; set; }

        public int TotalTrainingSessions { get; set; }

        public double AverageTrainingSessionLength { get; set; }
    }
}
