using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AlertConfiguration: IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        builder.ToTable("Alerts").HasKey(a => a.Id); 
        
         // Disaster Relationship
        builder.Property(a => a.DisasterId).IsRequired(false);

        // Basic Information
        builder.Property(a => a.Name).IsRequired().HasMaxLength(200);

        // Core alert information
        builder.Property(a => a.Description).IsRequired().HasMaxLength(2000);
        builder.Property(a => a.Type).IsRequired().HasConversion<string>();
        builder.Property(a => a.Severity).IsRequired().HasConversion<string>();

        // Temporal information
        builder.Property(a => a.IssuedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(a => a.ResolvedAt).IsRequired(false);

        // Location information (owned entity)
        builder.OwnsOne(a => a.Location, location =>
        {
            location.Property(l => l.Latitude).HasPrecision(9, 6);
            location.Property(l => l.Longitude).HasPrecision(9, 6);
            location.Property(l => l.Address).HasMaxLength(500);
            location.Property(l => l.City).HasMaxLength(100);
            location.Property(l => l.Region).HasMaxLength(100);
            location.Property(l => l.Country).HasMaxLength(100);
        });

        // Status and Instructions
        builder.Property(a => a.Status).IsRequired().HasConversion<string>();

        builder.Property(a => a.Instructions).HasMaxLength(2000);

        // Audit information
        builder.Property(a => a.IssuedBy).IsRequired();

        builder.Property(a => a.LastUpdatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        
        // Indexes
        builder.HasIndex(a => a.DisasterId);
        builder.HasIndex(a => a.Name);
        builder.HasIndex(a => a.Type);
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.Severity);
        builder.HasIndex(a => a.IssuedAt);

        // Alert ile Disaster arasında Bire Çok ilişki
        builder.HasOne(a => a.Disaster)
            .WithMany(d => d.Alerts);
        
        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}