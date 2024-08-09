
using AppCore.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    [EntityTypeConfiguration(typeof(SpecialityConfiguration))]
    public class Speciality
    {
        public int? SpecialityId { get; set; }
        public string? Name { get; set; }
        public int? EducationalInstitutionId { get; set; }
        public EducationalInstitution? EducationalInstitution { get; set; }
        public ICollection<AcademicGroup>? AcademicGroups { get; set; }
        public ICollection<Discipline>? Disciplines { get; set; }
    }
}
