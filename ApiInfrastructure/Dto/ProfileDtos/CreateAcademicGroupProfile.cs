using AppCore.Dto;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppCore.Models;

namespace Univ.Dto.ProfileDtos;
using AutoMapper;

public class CreateAcademicGroupProfile : Profile
{
    public CreateAcademicGroupProfile()
    {
        CreateMap<CreateAcademicGroupDto, AcademicGroup>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StudyYear, opt => opt.MapFrom(src => src.StudyYear))
            .ForMember(dest => dest.SpecialityId, opt => opt.MapFrom(src => src.SpecialityId));
    }
}