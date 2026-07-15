using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class UpdateSkillRatingRequest
    {
        public string SkillName { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
