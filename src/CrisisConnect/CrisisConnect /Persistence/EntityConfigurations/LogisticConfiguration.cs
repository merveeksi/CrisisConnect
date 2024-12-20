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
        
        // Basic Information
        builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Description).HasMaxLength(500);
        builder.Property(l => l.Type).IsRequired().HasConversion<string>();
        builder.Property(l => l.Status).IsRequired().HasConversion<string>();

        // Delivery Information
        builder.Property(l => l.SourceLocation).IsRequired().HasMaxLength(200);

        builder.Property(l => l.DestinationLocation).IsRequired().HasMaxLength(200);
        builder.Property(l => l.ExpectedDeliveryDate).IsRequired();

        // Content Information
        builder.Property(l => l.Content).IsRequired().HasMaxLength(500);
        builder.Property(l => l.Quantity).IsRequired().HasDefaultValue(1);
        builder.Property(l => l.Priority).HasMaxLength(20);
        
    
        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}