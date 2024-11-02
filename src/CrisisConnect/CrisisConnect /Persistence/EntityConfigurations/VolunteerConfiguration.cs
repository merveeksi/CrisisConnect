using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VolunteerConfiguration: IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("Volunteers").HasKey(v => v.Id);
        
        // Assignment
        builder.Property(v => v.TeamId).IsRequired(false);
        builder.Property(v => v.ShelterId).IsRequired(false);
        
        // Unique index eklemek
        builder.HasIndex(v => v.PhoneNumber, "UK_Teams_PhoneNumber").IsUnique();
        
        // Basic Information
        builder.Property(v => v.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(v => v.LastName).IsRequired().HasMaxLength(50);
        builder.Property(v => v.Email).HasMaxLength(100);
        builder.Property(v => v.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(v => v.Location).IsRequired().HasMaxLength(200);
        
        // Skills and Status
        builder.Property(v => v.Skills).HasMaxLength(500);
        builder.Property(v => v.IsAvailable).IsRequired().HasDefaultValue(true);

        // Resources
        builder.Property(v => v.ImageUrl).HasMaxLength(500);

        // Audit
        builder.Property(v => v.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(v => v.UpdatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

        // Indexes
        builder.HasIndex(v => new { v.FirstName, v.LastName });
        builder.HasIndex(v => v.TeamId);
        builder.HasIndex(v => v.ShelterId);
        builder.HasIndex(v => v.Location);
        builder.HasIndex(v => v.IsAvailable);
        
        
        builder.HasQueryFilter(v => !v.DeletedDate.HasValue); // Soft delete
    }
}