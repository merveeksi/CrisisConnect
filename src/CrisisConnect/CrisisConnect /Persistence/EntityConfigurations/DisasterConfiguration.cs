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
        builder.Property(d=>d.TeamId).HasColumnName("TeamId").IsRequired();
        builder.Property(d=>d.AlertId).HasColumnName("AlertId").IsRequired();
        builder.Property(d=>d.ResourceId).HasColumnName("ResourceId").IsRequired();
        builder.Property(d=>d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d=>d.Type).HasColumnName("Type").IsRequired();
        builder.Property(d=>d.Location).HasColumnName("Location").IsRequired();
        builder.Property(d=>d.Severity).HasColumnName("Severity").IsRequired();
        builder.Property(d=>d.DateOccurred).HasColumnName("DateOccurred").IsRequired();
        builder.Property(d=>d.Casualties).HasColumnName("Casualties").IsRequired();
        builder.Property(d=>d.Description).HasColumnName("Description").IsRequired();
        builder.Property(d=>d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d=>d.DeletedDate).HasColumnName("DeletedDate");

        // Disaster ile Alert arasında bir ilişki
        builder.HasOne(d => d.Alert)
            .WithMany(a => a.Disaster)
            .HasForeignKey(d => d.AlertId)
            .IsRequired(false); 
        
        // Disaster ile birden fazla Resource ilişkisi
        builder.HasMany(d => d.Resources)
            .WithOne(r => r.Disaster);

        // Disaster ile birden fazla Volunteer ilişkisi
        builder.HasMany(d => d.Volunteers)
            .WithOne(v => v.Disaster);
        
        builder.HasQueryFilter(d => !d.DeletedDate.HasValue); //soft delete, silinmiş olanları getirmemek için
    }
}