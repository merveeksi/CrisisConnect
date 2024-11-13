using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams").HasKey(t => t.Id);

        // Basic properties
        builder.Property(t => t.Name).IsRequired().HasMaxLength(200);
        builder.Property(t => t.Status).IsRequired().HasConversion<int>();
        builder.Property(t => t.Specialty).IsRequired().HasConversion<int>();
        builder.Property(t => t.MaxCapacity).IsRequired();
        builder.Property(t => t.CurrentMemberCount).IsRequired();
        builder.Property(t => t.IsActive).IsRequired();
        builder.Property(t => t.CurrentMission).HasMaxLength(500);
        builder.Property(t => t.MissionStartTime);
        builder.Property(t => t.ExpectedEndTime);
        builder.Property(t => t.CurrentLocation).HasMaxLength(500);
        builder.Property(t => t.Latitude);
        builder.Property(t => t.Longitude);

        // Relationships
        builder.HasOne(t => t.Center)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.CenterId);

        // Many-to-many relationship with Request
        builder.HasMany(t => t.Requests)
            .WithMany(r => r.Teams)
            .UsingEntity(j => j.ToTable("TeamRequests"));

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}