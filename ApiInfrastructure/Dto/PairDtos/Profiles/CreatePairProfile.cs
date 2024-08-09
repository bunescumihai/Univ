using AppCore.Models;
using AutoMapper;

namespace Univ.Dto.PairDtos.Profiles;

public class CreatePairProfile : Profile
{
    public CreatePairProfile()
    {
        CreateMap<CreatePairDto, Pair>()
            .ForMember(dest => dest.PairNumber, opt => opt.MapFrom(src => src.PairNumber))
            .ForMember(dest => dest.PairType, opt => opt.MapFrom(src => src.PairType))
            .ForMember(dest => dest.DisciplineId, opt => opt.MapFrom(src => src.DisciplineId))
            .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
            .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
            .ForMember(dest => dest.WeekDay, opt => opt.MapFrom(src => src.WeekDay));
    }
}