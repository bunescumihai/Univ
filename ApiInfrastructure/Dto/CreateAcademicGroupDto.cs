using AppCore.Models.Enum;

namespace AppCore.Dto;


public class CreateAcademicGroupDto
{ 
    public string Name { get; set; }
    public StudyYear StudyYear { get; set; }
    public int SpecialityId { get; set; }
}