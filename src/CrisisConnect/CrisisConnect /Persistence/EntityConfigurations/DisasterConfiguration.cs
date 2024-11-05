using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DisasterConfiguration:IEntityTypeConfiguration<Disaster>
{
    public void Configure(EntityTypeBuilder<Disaster> builder)
    {
        builder.ToTable("Disasters").HasKey(d => d.Id);
        
        // Primary Key
        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.CenterId).IsRequired(false);

        // Properties
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired().HasMaxLength(100); // Limiting length to avoid excessive data storage
        builder.Property(d => d.Type).HasColumnName("Type").IsRequired();
        builder.Property(d=>d.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(d => d.Status).HasColumnName("Status").IsRequired();

        // Location Information
        builder.Property(d => d.Address).HasColumnName("Address").IsRequired().HasMaxLength(100);
        builder.Property(d => d.EmergencyContactInfo).HasColumnName("EmergencyContactInfo").HasMaxLength(100);
        builder.Property(d=>d.ImpactAssessment).HasColumnName("ImpactAssessment").IsRequired();

        // Timing Information
        builder.Property(d => d.DateOccurred).HasColumnName("DateOccurred").IsRequired();
        builder.Property(d => d.DateResolved).HasColumnName("DateResolved");
        
        // Audit fields
        builder.Property(d => d.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(d => d.LastUpdatedAt).HasColumnName("LastUpdatedAt");
        
        
        //Disaster ile bire bir Center ilişkisi (Her afetin karışıklığı önlemek için tek bir net komuta merkezine ihtiyacı vardır)
        builder.HasOne(d => d.Center)
            .WithOne(c => c.Disaster)
            .HasForeignKey<Disaster>(d => d.Id)
            .IsRequired(false);
        
        
        builder.HasQueryFilter(d => !d.DeletedDate.HasValue); //soft delete, silinmiş olanları getirmemek için
    }
}