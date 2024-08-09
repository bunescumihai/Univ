using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using AppCore.Models.Enum;

namespace AppCore.DataDB
{
    public class PeDbContext : DbContext
    {
        public DbSet<AcademicGroup> AcademicGroups { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Discipline> Disciplines  { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitutions  { get; set; }
        public DbSet<Pair> Pairs  { get; set; }
        public DbSet<PairAcademicGroup> PairAcademicGroups  { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<Speciality> Specialities  { get; set; }
        public DbSet<Teacher> Teachers  { get; set; }
        public DbSet<TimeDistribution> TimeDistributions  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HELIA; Database=PE; User Id=mihai; Password=admin; Trusted_Connection=false; MultipleActiveResultSets=true;");
        }
    }
}
