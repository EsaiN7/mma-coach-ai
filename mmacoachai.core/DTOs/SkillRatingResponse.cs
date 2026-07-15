using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class SkillRatingResponse
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
