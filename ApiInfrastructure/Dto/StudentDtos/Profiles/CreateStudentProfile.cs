using AppCore.Models;
using Univ.Dto.StudentDtos;

namespace Univ.Dto.StudentDtos.Profiles;

public class CreateStudentProfile : AutoMapper.Profile
{
    public CreateStudentProfile()
    {
        CreateMap<CreateStudentDto, Student>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.IDNP, opt => opt.MapFrom(src => src.IDNP))
            .ForMember(dest => dest.AcademicGroupId, opt => opt.MapFrom(src => src.AcademicGroupId))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.LivesInADorm, opt => opt.MapFrom(src => src.LivesInADorm))
            .ForMember(dest => dest.FinancingForm, opt => opt.MapFrom(src => src.FinancingForm));
    }
}