using AppCore.Models.Enum;

namespace Univ.Dto.PairDtos;

public class CreatePairDto
{
    public int? PairNumber { get; set; }
    public PairType? PairType { get; set; }
    public int? DisciplineId { get; set; }
    public int? TeacherId { get; set; }
    public int? AuditoriumId { get; set; }
    public WeekDay? WeekDay { get; set; }
}