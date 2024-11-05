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
        
        // Address
        builder.Property(d => d.Address).HasColumnName("Address").IsRequired().HasMaxLength(100);

        // Status and Instructions
        builder.Property(a => a.Status).IsRequired().HasConversion<string>();
        builder.Property(a => a.Instructions).HasMaxLength(2000);
        
        // Indexes
        builder.HasIndex(a => a.DisasterId);
        builder.HasIndex(a => a.Name);
        builder.HasIndex(a => a.Type);
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.Severity);

        // Alert ile Disaster arasında Bire Çok ilişki
        builder.HasOne(a => a.Disaster)
            .WithMany(d => d.Alerts);
        
        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}