using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestConfiguration: IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests").HasKey(r => r.Id);
        
        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r=>r.Location).HasColumnName("Location").IsRequired();
        builder.Property(r => r.Status).HasColumnName("Status").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");
        
        // Request'in Resource ile bire-bir ilişkisi
        builder.HasOne(r => r.Resource)
            .WithMany(res => res.Requests)
            .HasForeignKey(r => r.ResourceId);
        
        // Request'in Volunteer ile bire-bir ilişkisi
        builder.HasOne(r => r.Volunteer)
            .WithMany(v => v.Requests)
            .HasForeignKey(r => r.VolunteerId);

        // Request'in Disaster ile ilişkisi
        builder.HasOne(r => r.Disaster)
            .WithMany(d => d.Requests)
            .HasForeignKey(r => r.DisasterId);

        // Request adının unique olması için index
        builder.HasIndex(r => r.Location, "UK_Requests_Description").IsUnique();
    
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}