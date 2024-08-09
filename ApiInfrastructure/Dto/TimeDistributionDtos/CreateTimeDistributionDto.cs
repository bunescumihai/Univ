using AppCore.Models;
using AppCore.Models.Enum;

namespace Univ.Dto.TimeDistributionDtos;

public class CreateTimeDistributionDto
{ 
    public int? PairNumber { get; set; }
    public TimeSpan? Begin { get; set; }
    public TimeSpan? End { get; set; }
    public int? EducationalInstitutionId { get; set; }
}