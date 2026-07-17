using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.DTOs
{
    public class UpdateTrainingSessionRequest
    {
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public String Notes { get; set; } = string.Empty;
    }
}
