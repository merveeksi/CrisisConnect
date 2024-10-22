using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DonorConfiguration: IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable("Donors").HasKey(d => d.Id);
        
        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(d => d.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(d => d.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}