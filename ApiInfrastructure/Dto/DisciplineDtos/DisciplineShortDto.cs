using AppCore.Models.Enum;

namespace Univ.Dto.DisciplineDtos;

public class DisciplineShortDto
{
    public int DisciplineId { get; set; }
    public string Name { get; set; }
    public EvaluationForm EvaluationForm { get; set; } = EvaluationForm.Exam;
    public byte ECTS { get; set; }
}