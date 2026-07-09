using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.Entities
{
    public class SkillRating
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public int Rating { get; set; }

        public Athlete Athlete { get; set; } = null;
    }
}
