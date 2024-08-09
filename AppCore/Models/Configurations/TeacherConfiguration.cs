using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(teacher => teacher.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(teacher => teacher.LastName).HasMaxLength(50).IsRequired();
        builder.Property(teacher => teacher.Phone).HasMaxLength(15).IsRequired();
        builder.Property(teacher => teacher.Email).HasMaxLength(100).IsRequired();
        builder.HasCheckConstraint("CK_Teachers_IDNP", "LEN(IDNP) = 13 AND IDNP NOT LIKE '%[^0-9]%'");
        builder.Property(teacher => teacher.ImagePath).HasMaxLength(255).IsRequired(false);

        builder.HasIndex(s => s.IDNP).IsUnique();
        builder.HasIndex(s => s.Phone).IsUnique();
        builder.HasIndex(s => s.Email).IsUnique();
        
        
        builder.HasOne(teacher => teacher.EducationalInstitution)
            .WithMany(educationalInstitution => educationalInstitution.Teachers)
            .HasForeignKey(t => t.EducationalInstitutionId)
            .IsRequired();

        builder.HasOne(t => t.Chief)
            .WithMany(c => c.Subordinates)
            .HasForeignKey(t => t.PersonId);
    }
}