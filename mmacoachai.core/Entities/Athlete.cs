using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace mmacoachai.core.Entities
{
    public class Athlete
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public decimal WeightLbs { get; set; }
        public string Stance { get; set; } = string.Empty;
        public int  ExperienceYears { get; set; }
        public string CoachNotes { get; set; } = string.Empty;

        // Navigation properties
        public Coach Coach { get; set; } = null;
        public ICollection<SkillRating> SkillRatings { get; set; } = new List<SkillRating>();
        public ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();

    }
}
