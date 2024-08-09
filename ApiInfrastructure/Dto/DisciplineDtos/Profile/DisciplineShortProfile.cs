using AppCore.Models;
using Univ;

namespace Univ.Dto.DisciplineDtos.Profile;

public class DisciplineShortProfile : AutoMapper.Profile
{
    public DisciplineShortProfile()
    {
        CreateMap<Discipline, DisciplineShortDto>()
            .ForMember(dest => dest.DisciplineId, opt => opt.MapFrom(src => src.DisciplineId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.EvaluationForm, opt => opt.MapFrom(src => src.EvaluationForm))
            .ForMember(dest => dest.ECTS, opt => opt.MapFrom(src => src.ECTS));
    }
}