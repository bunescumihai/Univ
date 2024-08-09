using AppCore.Models.Enum;

namespace Univ.Dto.PairDtos;

public class CreatePairAcademicGroupDto
{
    public int? PairId { get; set; }
    public int? AcademicGroupId { get; set; }
}