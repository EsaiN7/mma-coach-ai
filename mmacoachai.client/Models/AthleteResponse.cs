namespace mmacoachai.client.Models;

public class AthleteResponse
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string NickName { get; set; } = "";

    public string Stance { get; set; } = "";

    public int Age { get; set; }

    public decimal WeightLbs { get; set; }

    public int ExperienceYears { get; set; }
}