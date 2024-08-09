using AppCore.Models.Configurations;
using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    [EntityTypeConfiguration(typeof(EducationalGroupConfiguration))]
    public class AcademicGroup
    {
        public int? AcademicGroupId { get; set; }
        public string? Name { get; set; }
        public StudyYear? StudyYear { get; set; }
        public int? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<PairAcademicGroup>? PairAcademicGroups { get; set; }
    }
}
