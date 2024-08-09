using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class EducationalInstitutionConfiguration : IEntityTypeConfiguration<EducationalInstitution>
{
    public void Configure(EntityTypeBuilder<EducationalInstitution> builder)
    {
        builder.Property(educationalInstitution => educationalInstitution.Name).HasMaxLength(255).IsRequired();
        builder.Property(educationalInstitution => educationalInstitution.Address).HasMaxLength(255).IsRequired();
        builder.Property(educationalInstitution => educationalInstitution.EducationalInstitutionType).IsRequired();
       
        builder.HasOne(e => e.ParentEducationalInstitution)
            .WithMany(p => p.ChildEducationalInstitutions)
            .HasForeignKey(e => e.EducationalInstitutionId)
            .IsRequired(false);
    }
}