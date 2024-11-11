using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DisasterConfiguration : IEntityTypeConfiguration<Disaster>
{
    public void Configure(EntityTypeBuilder<Disaster> builder)
    {
        builder.ToTable("Disasters").HasKey(d => d.Id);

        // Primary Key
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(disasterId => disasterId.Value, value => new DisasterId(value));

        builder.Property(d => d.CenterId).IsRequired(false);

        // Properties
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired()
            .HasMaxLength(200); // Limiting length to avoid excessive data storage
        builder.Property(d => d.Type).HasColumnName("Type").IsRequired().HasConversion<int>();
        builder.Property(d => d.Status).HasColumnName("Status").IsRequired().HasConversion<int>();

        // Contact Information
        builder.OwnsOne(d => d.ContactInfo, contactInfoBuilder =>
        {
            contactInfoBuilder.Property(c => c.PhoneNumber).IsRequired().HasColumnName("phone_number").HasMaxLength(20);
            contactInfoBuilder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(100);
            contactInfoBuilder.OwnsOne(c => c.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
                addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
                addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(100).HasColumnName("country");
                addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
                addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
                addressBuilder.Property(a => a.Apartment).HasMaxLength(100).HasColumnName("apartment");
            });


            // Impact Assessment
            builder.OwnsOne(d => d.ImpactAssessment, impactAssessmentBuilder =>
            {
                impactAssessmentBuilder.Property(i => i.Magnitude).IsRequired().HasColumnName("Magnitude");
                impactAssessmentBuilder.Property(i => i.Severity).IsRequired().HasColumnName("Severity")
                    .HasConversion<int>();
                impactAssessmentBuilder.Property(i => i.EstimatedAffectedPopulation).IsRequired()
                    .HasColumnName("EstimatedAffectedPopulation");
                impactAssessmentBuilder.Property(i => i.InjuredCount).IsRequired().HasColumnName("InjuredCount");
                impactAssessmentBuilder.Property(i => i.ConfirmedCasualties).IsRequired()
                    .HasColumnName("ConfirmedCasualties");
            });

            // DateTime Information
            builder.OwnsOne(d => d.DateTime, dateTimeBuilder =>
            {
                dateTimeBuilder.Property(d => d.DateOccurred).IsRequired().HasColumnName("DateOccurred");
                dateTimeBuilder.Property(d => d.DateResolved).HasColumnName("DateResolved");
                dateTimeBuilder.Property(d => d.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                dateTimeBuilder.Property(d => d.LastUpdatedAt).HasColumnName("LastUpdatedAt");
            });


            //Disaster ile bire bir Center ilişkisi (Her afetin karışıklığı önlemek için tek bir net komuta merkezine ihtiyacı vardır)
            builder.HasOne(d => d.Center)
                .WithOne(c => c.Disaster)
                .HasForeignKey<Disaster>(d => d.Id)
                .IsRequired(false);
            
            // Indexes
            builder.HasIndex(d => d.Id);
            builder.HasIndex(d => d.CenterId);
            builder.HasIndex(d => d.Name);
            builder.HasIndex(d => d.Type);
            builder.HasIndex(d => d.Status);
            builder.HasIndex(d => d.ContactInfo);
            builder.HasIndex(d => d.ImpactAssessment);
            builder.HasIndex(d => d.DateTime);

            builder.HasQueryFilter(d => !d.DeletedDate.HasValue); //soft delete, silinmiş olanları getirmemek için
        });
    }
}
