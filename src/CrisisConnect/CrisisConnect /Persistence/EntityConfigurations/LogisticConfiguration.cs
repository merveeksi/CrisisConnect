using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LogisticConfiguration: IEntityTypeConfiguration<Logistic>
{
    public void Configure(EntityTypeBuilder<Logistic> builder)
    {
        builder.ToTable("Logistics").HasKey(l => l.Id);
        
        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Destination).HasColumnName("Description").IsRequired();
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
            .WithMany(d => d.Logistics)
            .HasForeignKey(l => l.DisasterId);
        
        // Logistics adının unique olması için index
        builder.HasIndex(l => l.Destination, "UK_Logistics_Destination").IsUnique();
    
        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}