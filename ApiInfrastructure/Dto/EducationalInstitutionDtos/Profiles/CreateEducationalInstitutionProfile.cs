using AppCore.Models;

namespace Univ.Dto.EducationalInstitutionDtos.Profiles;

public class CreateEducationalInstitutionProfile : AutoMapper.Profile
{
    public CreateEducationalInstitutionProfile()
    {
        CreateMap<CreateEducationalInstitutionDto, EducationalInstitution>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.ParentEducationalInstitutionId, opt => opt.MapFrom(src => src.ParentEducationalInstitutionId))
            .ForMember(dest => dest.EducationalInstitutionType,
                opt => opt.MapFrom(src => src.EducationalInstitutionType));
    }
}