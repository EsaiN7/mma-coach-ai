namespace mmacoachai.core.DTOs;

public class CreateAthleteRequest
{
    public int CoachId { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string NickName { get; set; } = "";

    public int Age { get; set; }

    public decimal WeightLbs { get; set; }

    public string Stance { get; set; } = "";

    public int ExperienceYears { get; set; }

    public string CoachNotes { get; set; } = "";
}