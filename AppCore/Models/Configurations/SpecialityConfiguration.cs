using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
{
    public void Configure(EntityTypeBuilder<Speciality> builder)
    {
        builder.Property(s => s.Name).HasMaxLength(255).IsRequired();
        
        builder.HasOne(s => s.EducationalInstitution)
            .WithMany(e => e.Specialities)
            .HasForeignKey(s => s.EducationalInstitutionId)
            .IsRequired();
    }
}