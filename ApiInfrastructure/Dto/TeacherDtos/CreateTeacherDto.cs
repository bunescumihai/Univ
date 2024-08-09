using AppCore.Models.Enum;

namespace Univ.Dto.TeacherDtos;

public class CreateTeacherDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IDNP { get; set; }
    public int? EducationalInstitutionId { get; set; }
    public int? ChiefId { get; set; }
    public Grade? Grade { get; set; }
    public AdministrationFunction? AdministrationFunction { get; set; }
}