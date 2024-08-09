using AppCore.Dto;
using AppCore.Models;

namespace Univ.Dto.ProfileDtos;
using AutoMapper;

public class AcademicGroupShortProfile : Profile
{
    public AcademicGroupShortProfile()
    {
        CreateMap<AcademicGroup, AcademicGroupShortDto>()
            .ForMember(dest => dest.AcademicGroupId, opt => opt.MapFrom(src => src.AcademicGroupId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}