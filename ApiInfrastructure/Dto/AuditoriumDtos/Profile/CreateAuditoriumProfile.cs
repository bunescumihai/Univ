using AppCore.Models;

namespace Univ.Dto.AuditoriumDtos.Profile;

public class CreateAuditoriumProfile : AutoMapper.Profile
{
    public CreateAuditoriumProfile()
    {
        CreateMap<CreateAuditoriumDto, Auditorium>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}