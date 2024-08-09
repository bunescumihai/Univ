using AppCore.Models.Configurations;
using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    [EntityTypeConfiguration(typeof(PairConfiguration))]
    public class Pair
    {
        public int? PairId { get; set; }
        
        public int? PairNumber { get; set; }
        public PairType? PairType { get; set; }
        public int? DisciplineId { get; set; }
        public Discipline? Discipline { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int? AuditoriumId { get; set; }
        public Auditorium? Auditorium { get; set; }
        public WeekDay? WeekDay { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<PairAcademicGroup> PairAacademicGroups { get; set; }

        public void SetUpdate(Pair pair)
        {
            PairType = pair.PairType;
            DisciplineId = pair.DisciplineId;
            TeacherId = pair.DisciplineId;
            Auditorium = pair.Auditorium;
        }
    }
}
