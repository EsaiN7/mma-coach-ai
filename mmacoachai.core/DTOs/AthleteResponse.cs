namespace mmacoachai.core.DTOs;

public class AthleteResponse
{
    public int Id { get; init; }

    public int CoachId { get; init; }

    public string FirstName { get; init; } = "";

    public string LastName { get; init; } = "";

    public string NickName { get; init; } = "";

    public int Age { get; init; }

    public decimal WeightLbs { get; init; }

    public string Stance { get; init; } = "";

    public int ExperienceYears { get; init; }

    public string CoachNotes { get; init; } = "";
}