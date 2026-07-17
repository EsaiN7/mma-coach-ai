using System.ComponentModel.DataAnnotations;

namespace mmacoachai.core.DTOs;

public class CreateAthleteRequest
{
    public int CoachId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = "";

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = "";

    [Required]
    [StringLength(50)]
    public string NickName { get; set; } = "";
    [Required]
    [Range(10, 100)]
    public int Age { get; set; }

    [Required]
    [Range(100, 400)]
    public decimal WeightLbs { get; set; }

    [Required]
    [StringLength(50)]
    public string Stance { get; set; } = "";

    [Required]
    public int ExperienceYears { get; set; }

    [StringLength(500)]
    public string CoachNotes { get; set; } = "";
}