using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ResourceConfiguration: IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable("Resources").HasKey(r => r.Id);
        
        builder.HasIndex(r => r.Location, "UK_Resources_Location").IsUnique();

        // Basic Information
        builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
        builder.Property(r => r.Type).IsRequired().HasConversion<string>();
        builder.Property(r => r.Quantity).IsRequired().HasDefaultValue(0);
        builder.Property(r => r.Location).IsRequired().HasMaxLength(200);

        // Additional Details
        builder.Property(r => r.Description).HasMaxLength(500);
        builder.Property(r => r.Unit).IsRequired().HasMaxLength(20);
        builder.Property(r => r.MinimumQuantity).IsRequired().HasDefaultValue(0);

        // Status
        builder.Property(r => r.IsAvailable).IsRequired().HasDefaultValue(true);
        builder.Property(r => r.ExpiryDate).IsRequired(false);

        // Tracking
        builder.Property(r => r.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(r => r.UpdatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

        // Indexes
        builder.HasIndex(r => r.Name);
        builder.HasIndex(r => r.Type);
        builder.HasIndex(r => r.Location);
        builder.HasIndex(r => r.IsAvailable);
        builder.HasIndex(r => r.ExpiryDate);
        
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }

}