using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ResourceConfiguration: IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable("Resources").HasKey(r => r.Id);
        
        builder.HasIndex(r => r.Location, "UK_Resources_Location").IsUnique();

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Name).HasColumnName("Name").IsRequired();
        builder.Property(r => r.Type).HasColumnName("Type").IsRequired(); 
        builder.Property(r => r.Quantity).HasColumnName("Quantity").IsRequired(); 
        builder.Property(r => r.Location).HasColumnName("Location").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        // Resource ile Disaster arasında bire-bir ilişki
        builder.HasOne(r => r.Disaster)
            .WithMany(d => d.Resources);
        
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }

}