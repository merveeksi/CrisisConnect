using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CenterConfiguration: IEntityTypeConfiguration<Center>
{
    public void Configure(EntityTypeBuilder<Center> builder)
    {
        builder.ToTable("Centers").HasKey(c => c.Id);
        
        builder.Property(a => a.DisasterId).IsRequired(false);
        
        // Basic Information
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Description).HasMaxLength(1000);
        builder.Property(c => c.Type).IsRequired().HasConversion<string>();
        builder.Property(c => c.Status).IsRequired().HasConversion<string>();

        // Location Properties
        builder.Property(c => c.Latitude).HasPrecision(9, 6);
        builder.Property(c => c.Longitude).HasPrecision(9, 6);
        builder.Property(c => c.Address).HasMaxLength(500);
        builder.Property(c => c.City).HasMaxLength(100);
        builder.Property(c => c.Region).HasMaxLength(100);
        builder.Property(c => c.Country).HasMaxLength(100);

        // Capacity and Staff
        builder.Property(c => c.TotalCapacity).IsRequired();
        builder.Property(c => c.CurrentOccupancy).IsRequired();
        builder.Property(c => c.AvailableBeds).IsRequired();
        builder.Property(c => c.TotalStaff).IsRequired();

        // Contact Information
        builder.Property(c => c.PhoneNumber).HasMaxLength(20);
        builder.Property(c => c.EmergencyPhone).HasMaxLength(20);
        builder.Property(c => c.Email).HasMaxLength(100);
        builder.Property(c => c.WebsiteUrl).HasMaxLength(255);

        // Operating Information
        builder.Property(c => c.Is24Hours).IsRequired();
        builder.Property(c => c.OpenTime).HasMaxLength(10);
        builder.Property(c => c.CloseTime).HasMaxLength(10);

        // Resources
        builder.Property(c => c.MainImageUrl).HasMaxLength(500);
        builder.Property(c => c.AdditionalImageUrls).HasMaxLength(2000);
        builder.Property(c => c.AvailableServices).HasMaxLength(1000);

        // Audit Fields
        builder.Property(c => c.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(c => c.LastUpdatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

        // Indexes
        builder.HasIndex(c => c.Name);
        builder.HasIndex(c => c.City);
        builder.HasIndex(c => c.Status);
        builder.HasIndex(c => new { c.Latitude, c.Longitude });
        
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue); 
    }
}