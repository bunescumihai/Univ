using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;


public class PairAcademicGroupConfiguration : IEntityTypeConfiguration<PairAcademicGroup>
{
    public void Configure(EntityTypeBuilder<PairAcademicGroup> builder)
    {
        builder.HasKey(pa => new { pa.PairId, pa.AcademicGroupId });
        
        builder.HasOne(pa => pa.Pair)
            .WithMany(p => p.PairAacademicGroups)
            .HasForeignKey(pa => pa.PairId);
        
        builder.HasOne(pa => pa.AcademicGroup)
            .WithMany(a => a.PairAcademicGroups)
            .HasForeignKey(pa => pa.AcademicGroupId);
    }
}