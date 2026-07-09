using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.Entities
{
    public class TrainingSession
    {
        public int id { get; set; }
        public int AthleteId { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public String Notes { get; set; } = string.Empty;

        public Athlete Athlete { get; set; } = null;
    }
}
