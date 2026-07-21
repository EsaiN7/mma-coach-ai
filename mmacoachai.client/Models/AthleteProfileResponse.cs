namespace mmacoachai.client.Models;

public class AthleteProfileResponse
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string CoachName { get; set; } = "";

    public int TotalTrainingSessions { get; set; }

    public double LengthOfAverageTrainingSession { get; set; }

    public List<SkillRatingResponse> SkillRatings { get; set; } = [];
}