using AppCore.Models;
using AutoMapper;

namespace Univ.Dto.PairDtos.Profiles;

public class CreatePaiAcademicGrouprProfile : Profile
{
    public CreatePaiAcademicGrouprProfile()
    {
        CreateMap<CreatePairAcademicGroupDto, PairAcademicGroup>()
            .ForMember(dest => dest.PairId, opt => opt.MapFrom(src => src.PairId))
            .ForMember(dest => dest.AcademicGroupId, opt => opt.MapFrom(src => src.AcademicGroupId));
    }
}