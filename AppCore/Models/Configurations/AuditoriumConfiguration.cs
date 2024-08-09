using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCore.Models.Configurations;

internal class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
{
    public void Configure(EntityTypeBuilder<Auditorium> builder)
    {
        builder.Property(auditorium => auditorium.Name).HasMaxLength(6).IsRequired();
    }
}