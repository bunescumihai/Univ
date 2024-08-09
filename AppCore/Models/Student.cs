using AppCore.Contracts;
using AppCore.Models.Configurations;
using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    [EntityTypeConfiguration(typeof(StudentConfiguration))]
    public class Student : Person, IPrototype<Student>
    {
        public bool? LivesInADorm { get; set; }
        
        public FinancingForm? FinancingForm { get; set; }
        
        public int? AcademicGroupId { get; set; }
        public AcademicGroup? AcademicGroup { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }

        public Student()
        {
            
        }
        
        private Student(Student student)
        {
            LivesInADorm = student.LivesInADorm;
        }
        
        public Student Clone()
        {
            return new Student(this);
        }

        public void SetUpdate(Student student)
        {
            base.SetUpdate(student);
        }
    }
}
