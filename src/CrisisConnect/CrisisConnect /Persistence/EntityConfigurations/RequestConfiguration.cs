using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestConfiguration: IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests").HasKey(r => r.Id);
        
        
        // Primary Key
        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();

        // Basic Request Information
        builder.Property(r => r.Title).HasColumnName("Title").IsRequired().HasMaxLength(100); // Setting a max length to control data size
        builder.Property(r => r.Description)
            .HasColumnName("Description")
            .HasMaxLength(500); // Optional max length for description

        builder.Property(r => r.Type).HasColumnName("Type").IsRequired();
        builder.Property(r => r.Status).HasColumnName("Status").IsRequired();
        builder.Property(r => r.Priority).HasColumnName("Priority").IsRequired();

        // Location Details
        builder.Property(r => r.City).HasColumnName("City").IsRequired().HasMaxLength(50);
        builder.Property(r => r.District).HasColumnName("District").HasMaxLength(50);
        builder.Property(r => r.DetailedAddress).HasColumnName("DetailedAddress").HasMaxLength(200);
        builder.Property(r => r.Latitude).HasColumnName("Latitude").HasPrecision(9, 6);
        builder.Property(r => r.Longitude).HasColumnName("Longitude").HasPrecision(9, 6);

        // Quantities and Requirements
        builder.Property(r => r.RequiredQuantity).HasColumnName("RequiredQuantity").IsRequired();
        builder.Property(r => r.FulfilledQuantity).HasColumnName("FulfilledQuantity");
        builder.Property(r => r.SpecialRequirements).HasColumnName("SpecialRequirements").HasMaxLength(200);
        builder.Property(r => r.RequiresSpecialTransport).HasColumnName("RequiresSpecialTransport").IsRequired();
        builder.Property(r => r.NumberOfPeopleAffected).HasColumnName("NumberOfPeopleAffected").IsRequired();

        // Timing Information
        builder.Property(r => r.DateRequested).HasColumnName("DateRequested").IsRequired();
        builder.Property(r => r.DateNeededBy).HasColumnName("DateNeededBy");
        builder.Property(r => r.DateAssigned).HasColumnName("DateAssigned");
        builder.Property(r => r.DateFulfilled).HasColumnName("DateFulfilled");

        // Contact Information
        builder.Property(r => r.RequestorName).HasColumnName("RequestorName").IsRequired().HasMaxLength(100);
        builder.Property(r => r.ContactPhone).HasColumnName("ContactPhone").IsRequired().HasMaxLength(20);
        builder.Property(r => r.AlternateContactPhone).HasColumnName("AlternateContactPhone").HasMaxLength(20);

        // Tracking
        builder.Property(r => r.IsUrgent).HasColumnName("IsUrgent").IsRequired();
        builder.Property(r => r.CancellationReason).HasColumnName("CancellationReason").HasMaxLength(200);
        builder.Property(r => r.Notes).HasColumnName("Notes").HasMaxLength(500);

        // Audit fields
        builder.Property(r => r.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(r => r.LastUpdatedAt).HasColumnName("LastUpdatedAt");
    
        
       //Request ile Shelter arasında bire bir ilişki
        builder.HasOne(r => r.Shelter)
            .WithOne(s => s.Request)
            .HasForeignKey<Request>(r => r.Id)
            .IsRequired(false);
    
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}