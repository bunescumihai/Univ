using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

internal class EducationalGroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
{
    public void Configure(EntityTypeBuilder<AcademicGroup> builder)
    {
        builder.Property(academicGroup => academicGroup.Name).HasMaxLength(7).IsRequired();
        builder.HasIndex(academicGroup => academicGroup.Name).IsUnique();

        builder.HasOne(a => a.Speciality)
            .WithMany(s => s.AcademicGroups)
            .HasForeignKey(a => a.SpecialityId);
    }
}