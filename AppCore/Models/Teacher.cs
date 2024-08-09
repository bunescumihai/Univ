using AppCore.Models.Configurations;
using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    [EntityTypeConfiguration(typeof(TeacherConfiguration))]
    public class Teacher : Person
    {
        public int? EducationalInstitutionId { get; set; }
        public EducationalInstitution? EducationalInstitution { get; set; }
        public AdministrationFunction? AdministrationFunction { get; set; }
        public int? ChiefId { get; set; }
        public Teacher? Chief { get; set; }
        public ICollection<Teacher>? Subordinates { get; set; }
        public Grade? Grade { get; set; } = 0;
    }
}
