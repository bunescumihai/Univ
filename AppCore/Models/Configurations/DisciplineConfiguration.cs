using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.Property(discipline => discipline.Code).HasMaxLength(20);
        builder.Property(discipline => discipline.Name).HasMaxLength(100);
        builder.Property(discipline => discipline.TotalHours).HasMaxLength(100);

        builder.HasOne(d => d.Speciality)
            .WithMany(s => s.Disciplines)
            .HasForeignKey(d => d.SpecialityId)
            .IsRequired();
    }
}