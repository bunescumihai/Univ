using AppCore.Models.Configurations;
using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    
    [EntityTypeConfiguration(typeof(DisciplineConfiguration))]
    public class Discipline
    {
        public int DisciplineId { get; set; }
        
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public int TotalHours { get; set; }
        
        public int DirectContactHours { get; set; }
        public int IndividualStudyHours { get; set; }
        public int CourseHours { get; set; }
        public int SeminarHours { get; set; }
        public int PracticalWorkHours { get; set; }
        public int ProjectHours { get; set; }
        public EvaluationForm EvaluationForm { get; set; } = EvaluationForm.Exam;
        public int? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public byte ECTS { get; set; }


        public void SetUpdate(Discipline discipline)
        {
            Code = discipline.Code;
            Name = discipline.Name;
            TotalHours = discipline.TotalHours;
            DirectContactHours = discipline.DirectContactHours;
            IndividualStudyHours = discipline.IndividualStudyHours;
            CourseHours = discipline.CourseHours;
            SeminarHours = discipline.SeminarHours;
            PracticalWorkHours = discipline.PracticalWorkHours;
            ProjectHours = discipline.ProjectHours;
            EvaluationForm = discipline.EvaluationForm;
            ECTS = discipline.ECTS;
        }
    }
}
