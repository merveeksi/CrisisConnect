using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AlertConfiguration: IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        builder.ToTable("Alerts").HasKey(a => a.Id);
        
        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Message).HasColumnName("Message").IsRequired();
        builder.Property(a=>a.Location).HasColumnName("Location").IsRequired();
        builder.Property(a=>a.Datelssued).HasColumnName("Datelssued").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}