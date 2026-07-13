using System;
using System.Collections.Generic;
using System.Text;
using mmacoachai.core.DTOs;

namespace mmacoachai.core.Mappers
{
    public static class TrainingSessionMapper
    {
       public static TrainingSessionResponse ToTrainingSessionResponse(Entities.TrainingSession trainingSession)
        {
            return new TrainingSessionResponse
            {
                Id = trainingSession.Id,
                AthleteId = trainingSession.AthleteId,
                Date = trainingSession.Date,
                DurationMinutes = trainingSession.DurationMinutes,
                Notes = trainingSession.Notes
            };
        }

    }
}
