using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CenterConfiguration: IEntityTypeConfiguration<Center>
{
    public void Configure(EntityTypeBuilder<Center> builder)
    {
        builder.ToTable("Centers").HasKey(c => c.Id);
        
        builder.HasIndex(c=>c.Name, "UK_Centers_Name").IsUnique();
        
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.Location).HasColumnName("Location").IsRequired();
        builder.Property(c => c.Capacity).HasColumnName("Capacity").IsRequired();
        builder.Property(c => c.CurrentStaff).HasColumnName("CurrentStaff").IsRequired();
        builder.Property(c => c.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue); 
    }
}