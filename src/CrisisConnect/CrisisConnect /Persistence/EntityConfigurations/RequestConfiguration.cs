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
        builder.Property(r => r.RequestedResources).HasColumnName("RequestedResources").IsRequired();
        builder.Property(r=>r.Location).HasColumnName("Location").IsRequired();
        builder.Property(r => r.Status).HasColumnName("Status").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}