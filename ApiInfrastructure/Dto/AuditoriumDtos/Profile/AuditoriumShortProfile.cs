using AppCore.Models;

namespace Univ.Dto.AuditoriumDtos.Profile;

public class AuditoriumShortProfile : AutoMapper.Profile
{
    public AuditoriumShortProfile()
    {
        CreateMap<Auditorium, AuditoriumShortDto>()
            .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}