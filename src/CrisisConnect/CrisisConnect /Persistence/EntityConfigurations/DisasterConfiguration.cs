using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DisasterConfiguration : IEntityTypeConfiguration<Disaster>
{
    public void Configure(EntityTypeBuilder<Disaster> builder)
    {
        builder.ToTable("Disasters").HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasConversion(
                disasterId => disasterId.Value,
                value => new DisasterId(value))
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(200);

        // ContactInfo configuration
        builder.OwnsOne(d => d.ContactInfo, contactBuilder =>
        {
            contactBuilder.Property(c => c.PhoneNumber).IsRequired();
            contactBuilder.Property(c => c.Email).HasMaxLength(100);
            
            contactBuilder.OwnsOne(c => c.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
                addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
                addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(100).HasColumnName("country");
                addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
                addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
                addressBuilder.Property(a => a.Apartment).HasMaxLength(100).HasColumnName("apartment");
            });
        });

        builder.Property(d => d.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(d => d.Status)
            .IsRequired()
            .HasConversion<int>();

        // ImpactAssessment ve DateTimeInfo için owned type configurations
        builder.OwnsOne(d => d.ImpactAssessment);
        builder.OwnsOne(d => d.DateTime);

        // Relationships
        builder.HasOne(d => d.Center)
            .WithOne(c => c.Disaster)
            .HasForeignKey<Center>(c => c.DisasterId);

        builder.HasMany(d => d.Shelters)
            .WithOne(s => s.Disaster)
            .HasForeignKey(s => s.DisasterId);

        builder.HasMany(d => d.Alerts)
            .WithOne(a => a.Disaster)
            .HasForeignKey(a => a.DisasterId);

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}
