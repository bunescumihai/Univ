using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class TimeDistributionConfiguration : IEntityTypeConfiguration<TimeDistribution>
{
    public void Configure(EntityTypeBuilder<TimeDistribution> builder)
    {
        builder.HasIndex(t => new { t.PairNumber, t.EducationalInstitutionId }).IsUnique();
        
        builder.HasOne(t => t.EducationalInstitution)
            .WithMany(e => e.TimeDistributions)
            .HasForeignKey(t => t.EducationalInstitutionId);

        builder.Property(t => t.Begin).HasColumnType("TIME(0)").IsRequired();
        builder.Property(t => t.End).HasColumnType("TIME(0)").IsRequired();
        builder.Property(t => t.PairNumber).IsRequired();
        

        builder.HasCheckConstraint("CK_TimeDistributions_Begin_End", "[Begin] < [End]");
    }
}