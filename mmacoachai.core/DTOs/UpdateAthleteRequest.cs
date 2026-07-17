using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class UpdateAthleteRequest
    {
        public decimal WeightLbs { get; set; }

        public int Age { get; set; }

        public string Stance { get; set; } = "";

        public int ExperienceYears { get; set; }

        public string CoachNotes { get; set; } = "";
    }
}
