using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

public class AttendenceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasOne(a => a.Student)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.PersonId)
            .IsRequired();
        
        builder.HasOne(a => a.Pair)
            .WithMany(p => p.Attendances)
            .HasForeignKey(a => a.PairId)
            .IsRequired();

        builder.Property(a => a.Date).HasColumnType("Date");
        builder.Property(a => a.Status).IsRequired(false);

        builder.HasIndex(p => new { p.PersonId, p.Date, p.PairId }).IsUnique();
            
    }
}