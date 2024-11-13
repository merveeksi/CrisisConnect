using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("Volunteers").HasKey(v => v.Id);

        // Primary Key
        builder.Property(v => v.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(volunteerId => volunteerId.Value, value => new VolunteerId(value));

        // Foreign Keys
        builder.Property(v => v.TeamId).IsRequired(false);
        builder.Property(v => v.ShelterId).IsRequired(false);

        // Basic Information
        builder.OwnsOne(v => v.FullName, fullNameBuilder =>
        {
            fullNameBuilder.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("first_name");
            
            fullNameBuilder.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("last_name");
        });

        builder.Property(v => v.PhoneNumber)
            .IsRequired()
            .HasColumnName("PhoneNumber");

        builder.OwnsOne(v => v.Email, emailBuilder =>
        {
            emailBuilder.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(100);
        });

        builder.OwnsOne(v => v.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
            addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
            addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(100).HasColumnName("country");
            addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
            addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
            addressBuilder.Property(a => a.Apartment).HasMaxLength(100).HasColumnName("apartment");
        });

        builder.Property(v => v.Skills)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("Skills");

        builder.Property(v => v.ImageUrl)
            .HasMaxLength(2000)
            .HasColumnName("ImageUrl");

        // Relationships
        
        // Volunteer ile Shelter arasında 1-1 ilişki
        builder.HasOne(v => v.Shelter)
            .WithOne(s => s.Volunteer)
            .HasForeignKey<Volunteer>(v => v.ShelterId);
        
        // Volunteer ile Team arasında 1-1 ilişki
        builder.HasOne(v => v.Team)
            .WithOne(t => t.Volunteer)
            .HasForeignKey<Volunteer>(v => v.TeamId);
        

        // Soft Delete Filter
        builder.HasQueryFilter(v => !v.DeletedDate.HasValue);
    }
}