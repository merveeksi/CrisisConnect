using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestResourceConfiguration: IEntityTypeConfiguration<RequestResource>
{
    public void Configure(EntityTypeBuilder<RequestResource> builder)
    {
        builder.ToTable("RequestResources"); //tablo adı

        builder.HasKey(rr => new { rr.RequestId, rr.ResourceId });
            
        builder.Property(rr => rr.RequestId)
            .HasColumnName("RequestId")
            .IsRequired();
        
        builder.Property(rr => rr.ResourceId)
            .HasColumnName("ResourceId")
            .IsRequired();

        builder.HasOne(rr => rr.Request)
            .WithMany(r => r.RequestResources)
            .HasForeignKey(rr => rr.RequestId);
            
        builder.HasOne(rr => rr.Resource)
            .WithMany(r => r.RequestResources)
            .HasForeignKey(rr => rr.ResourceId);
        
    }
}