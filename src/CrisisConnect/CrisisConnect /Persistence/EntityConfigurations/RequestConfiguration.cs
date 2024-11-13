using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests").HasKey(r => r.Id);

        // ShelterId dönüşümü
        builder.Property(r => r.ShelterId)
            .HasConversion(
                shelterId => shelterId.Value,
                value => new ShelterId(value));

        // Basic Request Information
        builder.Property(r => r.Name).IsRequired().HasMaxLength(200);
        builder.Property(r => r.Title).IsRequired().HasMaxLength(200);
        builder.Property(r => r.Description).IsRequired().HasMaxLength(2000);
        builder.Property(r => r.Type).IsRequired().HasConversion<int>();
        builder.Property(r => r.Status).IsRequired().HasConversion<int>();
        builder.Property(r => r.Priority).IsRequired().HasConversion<int>();

        // Location Details
        builder.Property(r => r.City).IsRequired().HasMaxLength(100);
        builder.Property(r => r.District).IsRequired().HasMaxLength(100);
        builder.Property(r => r.DetailedAddress).IsRequired().HasMaxLength(500);
        builder.Property(r => r.Latitude);
        builder.Property(r => r.Longitude);

        // Contact Information
        builder.Property(r => r.RequestorName).IsRequired().HasMaxLength(200);
        builder.Property(r => r.ContactPhone).IsRequired().HasMaxLength(20);
        builder.Property(r => r.AlternateContactPhone).HasMaxLength(20);

        // Relationships
        builder.HasOne(r => r.Shelter)
            .WithMany()
            .HasForeignKey(r => r.ShelterId);

        // Teams ilişkisi TeamConfiguration'da tanımlandı
        // builder.HasMany(r => r.Teams)
        //     .WithOne()
        //     .HasForeignKey("RequestId");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}