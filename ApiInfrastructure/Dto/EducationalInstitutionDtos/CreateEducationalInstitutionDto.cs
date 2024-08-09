using AppCore.Models.Enum;

namespace Univ.Dto.EducationalInstitutionDtos;

public class CreateEducationalInstitutionDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public EducationalInstitutionType? EducationalInstitutionType { get; set; }
    public int? ParentEducationalInstitutionId { get; set; }
    
}