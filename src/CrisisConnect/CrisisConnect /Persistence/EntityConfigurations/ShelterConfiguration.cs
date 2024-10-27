using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShelterConfiguration: IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.ToTable("Shelters").HasKey(s => s.Id);
        
        builder.HasIndex(s=>s.Name, "UK_Shelters_Name").IsUnique();
        builder.HasIndex(s=>s.ContactInfo, "UK_Shelters_ContactInfo").IsUnique();
        
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
        builder.Property(s => s.ContactInfo).HasColumnName("ContactInfo").IsRequired();
        builder.Property(s => s.Capacity).HasColumnName("Capacity").IsRequired();
        builder.Property(s => s.Status).HasColumnName("Status").IsRequired();
        builder.Property(s => s.CurrentOccupancy).HasColumnName("CurrentOccupancy").IsRequired();
        builder.Property(s => s.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(s => s.Location).HasColumnName("Location").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}