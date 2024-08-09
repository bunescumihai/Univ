using AppCore.Models;

namespace Univ.Dto.SpecialityDtos.Profiles;

public class CreateSpecialityProfile : AutoMapper.Profile
{
    public CreateSpecialityProfile()
    {
        CreateMap<CreateSpecialityDto, Speciality>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.EducationalInstitutionId, opt => opt.MapFrom(src => src.EducationalInstitutionId));
    }
}