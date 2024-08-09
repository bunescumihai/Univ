using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class PairConfiguration : IEntityTypeConfiguration<Pair>
{
    public void Configure(EntityTypeBuilder<Pair> builder)
    {
        builder.HasIndex(pair =>
            new {
                pair.PairNumber, pair.WeekDay, pair.TeacherId
            }).IsUnique();
        
        builder.HasIndex(pair =>
            new {
                pair.PairNumber, pair.AuditoriumId, pair.WeekDay
            }).IsUnique();
        

    }
}