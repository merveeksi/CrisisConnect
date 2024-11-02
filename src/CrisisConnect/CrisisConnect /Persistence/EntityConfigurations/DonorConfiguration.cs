using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DonorConfiguration: IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable("Donors").HasKey(d => d.Id);
        
        builder.HasIndex(d=>d.PhoneNumber, "UK_Donors_PhoneNumber").IsUnique();
        
        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.FullName).HasColumnName("FullName").IsRequired();
        builder.Property(d => d.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(d => d.Email).HasColumnName("Email");
        builder.Property(d => d.Location).HasColumnName("Location").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");
        
        
        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}