using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(student => student.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(student => student.LastName).HasMaxLength(50).IsRequired();
        builder.Property(student => student.Phone).HasMaxLength(15).IsRequired();
        builder.Property(student => student.Email).HasMaxLength(100).IsRequired(false);
        builder.Property(student => student.LivesInADorm).HasDefaultValue(false);
        builder.Property(student => student.ImagePath).HasMaxLength(255).IsRequired(false);

        builder.HasIndex(s => s.IDNP).IsUnique();
        builder.HasIndex(s => s.Phone).IsUnique();
        builder.HasIndex(s => s.Email).IsUnique();
        
        builder.HasOne(s => s.AcademicGroup)
            .WithMany(a => a.Students)
            .HasForeignKey(s => s.AcademicGroupId)
            .IsRequired();
    }
}