using AppCore.Models.Enum;

namespace Univ.Dto;

public class CreateStudentDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IDNP { get; set; }
    public int? AcademicGroupId { get; set; }
    public FinancingForm? FinancingForm { get; set; }
    public bool? LivesInADorm { get; set; }
}