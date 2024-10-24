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

        // Disaster adının unique olması için index
        builder.HasIndex(d => d.Name, "UK_Disasters_Name").IsUnique();
        
        // Disaster ile birden fazla Resource ilişkisi
        builder.HasMany(d => d.Resources)
            .WithOne(r => r.Disaster)
            .HasForeignKey(r => r.DisasterId);

        // Disaster ile birden fazla Volunteer ilişkisi
        builder.HasMany(d => d.Volunteers)
            .WithOne(v => v.Disaster)
            .HasForeignKey(v => v.DisasterId);
        
        builder.HasQueryFilter(d => !d.DeletedDate.HasValue); //soft delete, silinmiş olanları getirmemek için
    }
}