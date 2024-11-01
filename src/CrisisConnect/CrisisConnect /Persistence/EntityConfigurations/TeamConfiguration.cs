using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TeamConfiguration: IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams").HasKey(t => t.Id);
        
        // Primary Key
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();

        // Basic Information
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
        builder.Property(t => t.Specialty).HasColumnName("Specialty").IsRequired();

        builder.Property(t => t.Status).HasColumnName("Status").IsRequired();

        // Team Details
        builder.Property(t => t.MaxCapacity).HasColumnName("MaxCapacity").IsRequired();
        builder.Property(t => t.CurrentMemberCount).HasColumnName("CurrentMemberCount");
        builder.Property(t => t.IsActive).HasColumnName("IsActive").IsRequired();

        // Mission Information
        builder.Property(t => t.CurrentMission).HasColumnName("CurrentMission").HasMaxLength(200);
        builder.Property(t => t.MissionStartTime).HasColumnName("MissionStartTime");
        builder.Property(t => t.ExpectedEndTime).HasColumnName("ExpectedEndTime");

        // Location
        builder.Property(t => t.CurrentLocation).HasColumnName("CurrentLocation").HasMaxLength(100);
        builder.Property(t => t.Latitude).HasColumnName("Latitude").HasPrecision(9, 6);
        builder.Property(t => t.Longitude).HasColumnName("Longitude").HasPrecision(9, 6);
        
        // Team ile Volunteer arasında 1-1 ilişki
        builder.HasOne(t => t.Volunteer)
            .WithOne(v => v.Team)
            .HasForeignKey<Team>(t => t.Id);
        
        
        builder.HasQueryFilter(t => !t.DeletedDate.HasValue); 
    }
}