using AppCore.Models.Enum;

namespace AppCore.Models;

public class EducationalInstitution
{
    public int? EducationalInstitutionId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public EducationalInstitutionType? EducationalInstitutionType { get; set; }
    public int? ParentEducationalInstitutionId { get; set; }
    public EducationalInstitution? ParentEducationalInstitution { get; set; }
    public ICollection<EducationalInstitution>? ChildEducationalInstitutions { get; set; }
    public ICollection<Speciality>? Specialities { get; set; }
    public ICollection<Teacher>? Teachers { get; set; }
    public ICollection<TimeDistribution> TimeDistributions { get; set; }
}