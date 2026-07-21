namespace mmacoachai.client.Models;

public class TrainingSessionResponse
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int Duration { get; set; }

    public string Notes { get; set; } = "";
}