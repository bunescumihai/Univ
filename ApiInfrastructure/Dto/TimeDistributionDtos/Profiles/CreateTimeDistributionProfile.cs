using AppCore.Models;

namespace Univ.Dto.TimeDistributionDtos.Profiles;

public class CreateTimeDistributionProfile : AutoMapper.Profile
{
    public CreateTimeDistributionProfile()
    {
        CreateMap<CreateTimeDistributionDto, TimeDistribution>()
            .ForMember(dest => dest.PairNumber, opt => opt.MapFrom(src => src.PairNumber))
            .ForMember(dest => dest.Begin, opt => opt.MapFrom(src => src.Begin))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
            .ForMember(dest => dest.EducationalInstitutionId, opt => opt.MapFrom(src => src.EducationalInstitutionId));
    }
}