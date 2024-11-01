using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShelterConfiguration: IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.ToTable("Shelters").HasKey(s => s.Id);
        
        // Primary Key
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();

        // Basic Information
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
        builder.Property(s => s.Status).HasColumnName("Status").IsRequired();

        // Location
        builder.Property(s => s.City).HasColumnName("City").IsRequired().HasMaxLength(50);
        builder.Property(s => s.District).HasColumnName("District").HasMaxLength(50);
        builder.Property(s => s.Address).HasColumnName("Address").HasMaxLength(200);
        builder.Property(s => s.Latitude).HasColumnName("Latitude").HasPrecision(9, 6);
        builder.Property(s => s.Longitude).HasColumnName("Longitude").HasPrecision(9, 6);

        // Capacity Management
        builder.Property(s => s.TotalCapacity).HasColumnName("TotalCapacity").IsRequired();
        builder.Property(s => s.CurrentOccupancy).HasColumnName("CurrentOccupancy");
        builder.Property(s => s.HasAccessibility).HasColumnName("HasAccessibility").IsRequired();

        // Contact & Facilities
        builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
        builder.Property(s => s.EmergencyPhone).HasColumnName("EmergencyPhone").HasMaxLength(20);
        builder.Property(s => s.HasMedicalSupport).HasColumnName("HasMedicalSupport").IsRequired();
        builder.Property(s => s.HasKitchen).HasColumnName("HasKitchen").IsRequired();

        // Tracking
        builder.Property(s => s.OpenedAt).HasColumnName("OpenedAt").IsRequired();
        builder.Property(s => s.ClosedAt).HasColumnName("ClosedAt");
        
        // Shelter ile Volunteer arasında 1-1 ilişki
        builder.HasOne(s => s.Volunteer)
            .WithOne(v => v.Shelter)
            .HasForeignKey<Shelter>(s => s.Id)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}