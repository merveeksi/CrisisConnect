using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LogisticConfiguration: IEntityTypeConfiguration<Logistic>
{
    public void Configure(EntityTypeBuilder<Logistic> builder)
    {
        builder.ToTable("Logistics").HasKey(l => l.Id);
        
        // Logistics adının unique olması için index
        builder.HasIndex(l => l.Name, "UK_Logistics_Name").IsUnique();
        
        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.ResourceId).HasColumnName("ResourceId").IsRequired();
        builder.Property(l => l.Destination).HasColumnName("Destination").IsRequired();
        builder.Property(l => l.EstimatedArrival).HasColumnName("EstimatedArrival").IsRequired();
        builder.Property(l => l.CurrentStatus).HasColumnName("CurrentStatus").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");
        
        // Logistics ile Resource arasında bire-bir ilişki
        builder.HasOne(l => l.Resource)
            .WithMany(r => r.Logistics)
            .HasForeignKey(l => l.ResourceId);
        
        // Logistics ile Disaster arasında bire-bir ilişki
        builder.HasOne(l => l.Disaster)
            .WithMany(d => d.Logistics);
        
    
        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}