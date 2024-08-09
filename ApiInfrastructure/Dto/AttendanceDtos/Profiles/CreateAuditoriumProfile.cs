using AppCore.Models;
using Univ.Dto.AttendanceDtos;

namespace Univ.Dto.AuditoriumDtos.Profile;

public class CreateAttendanceProfile : AutoMapper.Profile
{
    public CreateAttendanceProfile()
    {
        CreateMap<CreateAttendanceDto, Attendance>()
            .ForMember(dest => dest.PairId, opt => opt.MapFrom(src => src.PairId))
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
    }
}