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
        

        // Relationships
        builder.HasMany(r => r.Centers)
            .WithMany(c => c.Resources)
            .UsingEntity(j => j.ToTable("CenterResources"));

        builder.HasMany(r => r.Requests)
            .WithMany(req => req.Resources)
            .UsingEntity(j => j.ToTable("RequestResources"));

        builder.HasMany(r => r.Shelters)
            .WithMany(s => s.Resources)
            .UsingEntity(j => j.ToTable("ShelterResources"));

        builder.HasMany(r => r.Donors)
            .WithMany(d => d.Resources)
            .UsingEntity(j => j.ToTable("DonorResources"));

        // Indexes
        builder.HasIndex(r => r.Name);
        builder.HasIndex(r => r.Type);
        builder.HasIndex(r => r.Location);
        builder.HasIndex(r => r.IsAvailable);
        builder.HasIndex(r => r.ExpiryDate);
        
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }

}