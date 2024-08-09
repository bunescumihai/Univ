using AppCore.Models;

namespace Univ.Dto.TeacherDtos.Profiles;

public class CreateTeacherProfile : AutoMapper.Profile
{
    public CreateTeacherProfile()
    {
        CreateMap<CreateTeacherDto, Teacher>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.IDNP, opt => opt.MapFrom(src => src.IDNP))
            .ForMember(dest => dest.ChiefId, opt => opt.MapFrom(src => src.ChiefId))
            .ForMember(dest => dest.EducationalInstitutionId, opt => opt.MapFrom(src => src.EducationalInstitutionId))
            .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.AdministrationFunction, opt => opt.MapFrom(src => src.AdministrationFunction))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));
    }
}