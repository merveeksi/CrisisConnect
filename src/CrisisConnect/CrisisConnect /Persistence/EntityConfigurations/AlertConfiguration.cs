using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AlertConfiguration: IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        builder.ToTable("Alerts").HasKey(a => a.Id);
        
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(alertId => alertId.Value, value => new AlertId(value));
        
        builder.Property(a => a.DisasterId).IsRequired(false);

        // Basic Information
        builder.Property(a => a.Name).IsRequired().HasMaxLength(200);

        // Core alert information
        builder.Property(a => a.Description).IsRequired().HasMaxLength(2000);
        builder.Property(a => a.Type).IsRequired().HasConversion<int>();
        builder.Property(a => a.Severity).IsRequired().HasConversion<int>();
        
        // Address
        builder.OwnsOne(a => a.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
            addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
            addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(100).HasColumnName("country");
            addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
            addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
            addressBuilder.Property(a => a.Apartment).HasMaxLength(100).HasColumnName("apartment");
        });

        // Status and Instructions
        builder.Property(a => a.Status).IsRequired().HasConversion<int>();
        builder.Property(a => a.Instructions).HasMaxLength(2000);
        
        // Indexes
        builder.HasIndex(a => a.Id);
        builder.HasIndex(a => a.DisasterId);
        builder.HasIndex(a => a.Name);
        builder.HasIndex(a => a.Description);
        builder.HasIndex(a => a.Type);
        builder.HasIndex(a=> a.Severity);
        builder.HasIndex(a=> a.Address);
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.Instructions);

        // Alert ile Disaster Arasında Bire Çok ilişki
        builder.HasOne(a => a.Disaster)
            .WithMany(d => d.Alerts);
        
        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}