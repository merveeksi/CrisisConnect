using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TeamConfiguration: IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams").HasKey(t => t.Id);
        
        // Unique index eklemek
        builder.HasIndex(t => t.Name, "UK_Teams_Name").IsUnique();
        
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.Specialty).HasColumnName("Specialty").IsRequired();
        builder.Property(t => t.CurrentAssignment).HasColumnName("CurrentAssignment").IsRequired();
        builder.Property(t => t.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");
        
        // Team ile Volunteer arasında bire-çok ilişki
        builder.HasMany(t => t.Volunteers)
            .WithOne(v => v.Team)
            .HasForeignKey(v => v.TeamId);

        // Team'in Disaster ile ilişkisi
        builder.HasOne(t => t.Disaster)
            .WithMany(d => d.Teams);
        
        builder.HasQueryFilter(t => !t.DeletedDate.HasValue); 
    }
}