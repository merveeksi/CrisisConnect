using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CenterConfiguration : IEntityTypeConfiguration<Center>
{
    public void Configure(EntityTypeBuilder<Center> builder)
    {
        builder.ToTable("Centers").HasKey(c => c.Id);

        // Basic properties
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Description).HasMaxLength(2000);
        builder.Property(c => c.Type).IsRequired().HasConversion<int>();
        builder.Property(c => c.Status).IsRequired().HasConversion<int>();
        
        // Location properties
        builder.Property(c => c.Latitude).IsRequired();
        builder.Property(c => c.Longitude).IsRequired();
        builder.Property(c => c.Address).IsRequired().HasMaxLength(500);
        builder.Property(c => c.City).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Region).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Country).IsRequired().HasMaxLength(100);

        // Contact properties
        builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(c => c.EmergencyPhone).HasMaxLength(20);
        builder.Property(c => c.Email).HasMaxLength(100);
        builder.Property(c => c.WebsiteUrl).HasMaxLength(500);

        // Relationships
        builder.HasOne(c => c.Disaster)
            .WithOne(d => d.Center)
            .HasForeignKey<Center>("DisasterId");

        builder.HasMany(c => c.Teams)
            .WithOne(t => t.Center)
            .HasForeignKey(t => t.CenterId);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
