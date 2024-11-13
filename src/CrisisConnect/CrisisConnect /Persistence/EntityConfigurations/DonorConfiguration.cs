using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable("Donors").HasKey(d => d.Id);

        // FullName value object yapılandırması
        builder.OwnsOne(d => d.FullName, fullNameBuilder =>
        {
            fullNameBuilder.Property(f => f.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            fullNameBuilder.Property(f => f.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.Property(d => d.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(d => d.Email)
            .HasMaxLength(100);

        builder.Property(d => d.Location)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}