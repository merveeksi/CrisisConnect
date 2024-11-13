using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.ToTable("Shelters").HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(
                shelterId => shelterId.Value,
                value => new ShelterId(value))
            .ValueGeneratedOnAdd();

        builder.Property(s => s.DisasterId);

        // Basic Information
        builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
        builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(20);
        
        // Address configuration
        builder.OwnsOne(s => s.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
            addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
            addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(100).HasColumnName("country");
            addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
            addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
            addressBuilder.Property(a => a.Apartment).HasMaxLength(100).HasColumnName("apartment");
        });

        builder.Property(s => s.Status).IsRequired().HasConversion<int>();

        // Relationships
        builder.HasOne(s => s.Disaster)
            .WithMany(d => d.Shelters)
            .HasForeignKey(s => s.DisasterId);

        builder.HasOne(s => s.Volunteer)
            .WithOne(v => v.Shelter)
            .HasForeignKey<Shelter>(s => s.VolunteerId)
            .IsRequired(false);

        builder.HasOne(s => s.Request)
            .WithOne(r => r.Shelter)
            .HasForeignKey<Request>(r => r.ShelterId);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}
