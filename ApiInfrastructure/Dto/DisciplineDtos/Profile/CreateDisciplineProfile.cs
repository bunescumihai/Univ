

using AppCore.Models;

namespace Univ.Dto.DisciplineDtos.Profile;

public class CreateDisciplineProfile : AutoMapper.Profile
{
    public CreateDisciplineProfile()
    {
        CreateMap<CreateDisciplineDto, Discipline>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TotalHours, opt => opt.MapFrom(src => src.TotalHours))
            .ForMember(dest => dest.DirectContactHours, opt => opt.MapFrom(src => src.DirectContactHours))
            .ForMember(dest => dest.IndividualStudyHours, opt => opt.MapFrom(src => src.IndividualStudyHours))
            .ForMember(dest => dest.CourseHours, opt => opt.MapFrom(src => src.CourseHours))
            .ForMember(dest => dest.SeminarHours, opt => opt.MapFrom(src => src.SeminarHours))
            .ForMember(dest => dest.PracticalWorkHours, opt => opt.MapFrom(src => src.PracticalWorkHours))
            .ForMember(dest => dest.ProjectHours, opt => opt.MapFrom(src => src.ProjectHours))
            .ForMember(dest => dest.EvaluationForm, opt => opt.MapFrom(src => src.EvaluationForm))
            .ForMember(dest => dest.ECTS, opt => opt.MapFrom(src => src.ECTS))
            .ForMember(dest => dest.SpecialityId, opt => opt.MapFrom(src => src.SpecialityId));
    }
}