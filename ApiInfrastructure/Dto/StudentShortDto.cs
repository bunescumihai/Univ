namespace AppCore.Dto;

public class StudentShortDto
{
    public int? PersonId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IDNP { get; set; }
    public int? AcademicGroupId { get; set; }
    public string? ImagePath { get; set; }
}