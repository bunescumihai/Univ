using AppCore.Models.Enum;

namespace Univ.Dto.DisciplineDtos;

public class CreateDisciplineDto
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int? TotalHours { get; set; }
    public int? DirectContactHours { get; set; }
    public int? IndividualStudyHours { get; set; }
    public int? CourseHours { get; set; }
    public int? SeminarHours { get; set; }
    public int? PracticalWorkHours { get; set; }
    public int? ProjectHours { get; set; }
    public EvaluationForm? EvaluationForm { get; set; }
    public byte? ECTS { get; set; }
    public int? SpecialityId { get; set; }
}