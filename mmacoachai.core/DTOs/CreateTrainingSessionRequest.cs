using mmacoachai.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class CreateTrainingSessionRequest
    {
        public int AthleteId { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public String Notes { get; set; } = string.Empty;
    }
}
