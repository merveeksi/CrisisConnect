using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DisasterConfiguration:IEntityTypeConfiguration<Disaster>
{
    public void Configure(EntityTypeBuilder<Disaster> builder)
    {
        builder.ToTable("Disasters").HasKey(d => d.Id);
        
        builder.Property(d=>d.Id).HasColumnName("Id").IsRequired();   //isRequired = zorunlu
        builder.Property(d=>d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d=>d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d=>d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue); //soft delete, silinmiş olanları getirmemek için
    }
}